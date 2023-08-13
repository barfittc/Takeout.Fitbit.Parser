using System.Collections;
using System.Text.Json;
using System.IO.Compression;
using System;
using System.Diagnostics;

namespace Takeout.Fitbit.Parser
{
    public partial class Form1 : Form
    {
        #region Init
        public IEnumerable<CheckBox> Checkboxes => this.groupBox1.Controls.OfType<CheckBox>();
        public Settings Settings = new Settings();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Settings = JsonSerializer.Deserialize<Settings>(Properties.Settings.Default.Setting ?? "{}") ?? new Settings();
            foreach (CheckBox checkbox in Checkboxes)
            {
                if (Settings.Checked.TryGetValue(checkbox.Text, out bool isChecked))
                {
                    checkbox.Checked = isChecked;
                }
            }
            maskedTextBox1.Text = Settings.FromValue.ToString();
            comboBox1.Text = Settings.FromType.ToString();
            textBox3.Text = Settings.DateFormat.ToString();
        }

        private void includeCol_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Checked[((CheckBox)sender).Text] = ((CheckBox)sender).Checked;
            List<(string, int)> items = new List<(string, int)>();
            foreach (KeyValuePair<string, bool> checkbox in Settings.Checked)
            {
                Settings.Checked[checkbox.Key] = checkbox.Value;
                if (!checkbox.Value)
                    continue;
                if (!Settings.Order.TryGetValue(checkbox.Key, out int order))
                {
                    order = 99;
                }
                items.Add((checkbox.Key, order));
            }
            listView1.Items.Clear();
            Settings.Order.Clear();
            int count = 0;
            foreach (string item in items
                .OrderBy(t => t.Item2)
                .Select(t => t.Item1)
                )
            {
                listView1.Items.Add(item);
                Settings.Order.Add(item, count++);
            }
        }
        #endregion
        #region ListBox Reordering
        private const string REORDER = "Reorder";
        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (!listView1.AllowDrop)
            {
                return;
            }
            listView1.DoDragDrop(REORDER, DragDropEffects.Move);
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (!listView1.AllowDrop)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            if (!e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            String text = (String)e.Data.GetData(REORDER.GetType());
            if (text.CompareTo(REORDER) == 0)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listView1_DragOver(object sender, DragEventArgs e)
        {
            if (!listView1.AllowDrop)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            if (!e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            Point cp = listView1.PointToClient(new Point(e.X, e.Y));
            ListViewItem hoverItem = listView1.GetItemAt(cp.X, cp.Y);
            if (hoverItem == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            foreach (ListViewItem moveItem in listView1.SelectedItems)
            {
                if (moveItem.Index == hoverItem.Index)
                {
                    e.Effect = DragDropEffects.None;
                    hoverItem.EnsureVisible();
                    return;
                }
            }

            String text = (String)e.Data.GetData(REORDER.GetType());
            if (text.CompareTo(REORDER) == 0)
            {
                e.Effect = DragDropEffects.Move;
                hoverItem.EnsureVisible();
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (!listView1.AllowDrop)
            {
                return;
            }
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            Point cp = listView1.PointToClient(new Point(e.X, e.Y));
            ListViewItem dragToItem = listView1.GetItemAt(cp.X, cp.Y);
            if (dragToItem == null)
            {
                return;
            }
            int dropIndex = dragToItem.Index;
            if (dropIndex > listView1.SelectedItems[0].Index)
            {
                dropIndex++;
            }
            ArrayList insertItems =
              new ArrayList(listView1.SelectedItems.Count);
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                insertItems.Add(item.Clone());
            }
            for (int i = insertItems.Count - 1; i >= 0; i--)
            {
                ListViewItem insertItem =
                 (ListViewItem)insertItems[i];
                listView1.Items.Insert(dropIndex, insertItem);
            }
            foreach (ListViewItem removeItem in listView1.SelectedItems)
            {
                listView1.Items.Remove(removeItem);
            }

            // set order
            Settings.Order.Clear();
            int count = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                Settings.Order.Add(item.Text, count++);
            }
        }
        #endregion
        #region Buttons
        private void reset_Click(object sender, EventArgs e)
        {
            foreach (CheckBox checkbox in Checkboxes)
            {
                checkbox.Checked = false;
            }
            Properties.Settings.Default.Setting = "{}";
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            listView1.Items.Clear();
            Form1_Load(sender, e);
        }

        private void save_Click(object sender, EventArgs e)
        {
            Settings.FromValue = int.Parse(maskedTextBox1.Text);
            Settings.FromType = comboBox1.Text;
            Settings.DateFormat = textBox3.Text;

            Properties.Settings.Default.Setting = JsonSerializer.Serialize(Settings);
            Properties.Settings.Default.Save();

            List<string> list = new List<string>
            {
                "Date"
            };
            foreach (ListViewItem item in listView1.Items)
            {
                list.Add(item.Text);
            }
            DateTime dateTime = (dateTimePicker2.Checked ? dateTimePicker2.Value : DateTime.Now);
            if (!dateTimePicker2.Checked)
                switch (Settings.FromType)
                {
                    case "Days":
                        dateTime = dateTime.AddDays(-Settings.FromValue);
                        break;
                    case "Weeks":
                        dateTime = dateTime.AddDays(-Settings.FromValue * 7);
                        dateTime = dateTime.AddDays(-(int)dateTime.DayOfWeek);
                        break;
                    case "Months":
                        dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month - Settings.FromValue, 1);
                        break;
                }

            var progress = new Progress<string>();
            progress.ProgressChanged += Progress_ProgressChanged;
            progressBar1.Style = ProgressBarStyle.Marquee;
            Task.Factory
                .StartNew(async () => await Run(
                    textBox1.Text,
                    textBox2.Text,
                    dateTime.StartOfDay(),
                    textBox3.Text,
                    list.ToArray(),
                    progress
                ))
                .ContinueWith((_) =>
                {
                    if (_.Result.Exception?.InnerException?.Message != null)
                    {
                        ((IProgress<string>)progress).Report("Error");
                        MessageBox.Show(_.Result.Exception.InnerException.Message);
                    }
                });
        }

        private void Progress_ProgressChanged(object? sender, string e)
        {
            label4.Text = e;
            if (e == "Error" || e == "Complete")
                progressBar1.Style = ProgressBarStyle.Continuous;
        }

        private void saveAs_Click(object sender, EventArgs e)
        {
            var result = saveFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                this.textBox2.Text = saveFileDialog1.FileName;
            }
        }

        private void findZip_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                this.textBox1.Text = openFileDialog1.FileName;
            }
        }
        #endregion

        public async Task Run(string sourceZip, string destinationCsv, DateTime from, string dateFormat, string[] columns, IProgress<string> progress)
        {
            if (string.IsNullOrWhiteSpace(sourceZip)) throw new ArgumentNullException(nameof(sourceZip));
            if (string.IsNullOrWhiteSpace(destinationCsv)) throw new ArgumentNullException(nameof(destinationCsv));

            progress.Report("Setup");
            var dirSourceFiles = new DirectoryInfo(Path.Combine(
                Path.GetTempPath(),
                typeof(Program)?.Assembly?.GetName()?.Name ?? "Fitbit.TakeOut",
                Path.GetFileNameWithoutExtension(sourceZip)
            ));

            // setup
            progress.Report("Extracting Zip");
            var data = new Data(dirSourceFiles, from, dateFormat);
#if DEBUG
            if (!dirSourceFiles.Exists)
            {
                Directory.CreateDirectory(dirSourceFiles.FullName);
                // unzip
                ZipFile.ExtractToDirectory(sourceZip, dirSourceFiles.FullName);
            }
#else
            if (dirSourceFiles.Exists)
                Directory.Delete(dirSourceFiles.FullName, true);
            Directory.CreateDirectory(dirSourceFiles.FullName);

            // unzip
            ZipFile.ExtractToDirectory(sourceZip, dirSourceFiles.FullName);
#endif
            // parse, and save Data
            progress.Report("Parsing Data");
            var csv = new Csv(data, columns);
            await csv.Save(destinationCsv);

            // cleanup
            progress.Report("Cleanup");
#if DEBUG
#else
            Directory.Delete(dirSourceFiles.FullName, true);
            dirSourceFiles.ClearCache();
#endif
            progress.Report("Complete");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings");
            Process.Start(sInfo);
        }
    }
}