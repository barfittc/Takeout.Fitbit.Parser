namespace Takeout.Fitbit.Parser
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button2 = new Button();
            label2 = new Label();
            button3 = new Button();
            button4 = new Button();
            groupBox1 = new GroupBox();
            checkBox24 = new CheckBox();
            checkBox20 = new CheckBox();
            checkBox10 = new CheckBox();
            checkBox9 = new CheckBox();
            checkBox7 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox12 = new CheckBox();
            checkBox13 = new CheckBox();
            checkBox16 = new CheckBox();
            checkBox17 = new CheckBox();
            checkBox18 = new CheckBox();
            checkBox19 = new CheckBox();
            checkBox22 = new CheckBox();
            checkBox23 = new CheckBox();
            checkBox11 = new CheckBox();
            checkBox14 = new CheckBox();
            checkBox15 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            checkBox8 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            groupBox2 = new GroupBox();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            label3 = new Label();
            comboBox1 = new ComboBox();
            maskedTextBox1 = new MaskedTextBox();
            progressBar1 = new ProgressBar();
            label4 = new Label();
            linkLabel1 = new LinkLabel();
            textBox3 = new TextBox();
            dateTimePicker2 = new DateTimePicker();
            label5 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 0;
            label1.Text = "Takeout zip File";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "TakeoutZipFile|*.zip";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Filter = "Comma Seperated List|*.csv";
            // 
            // button1
            // 
            button1.Location = new Point(415, 32);
            button1.Name = "button1";
            button1.Size = new Size(30, 23);
            button1.TabIndex = 1;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += findZip_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 32);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(403, 23);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(13, 150);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(402, 23);
            textBox2.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(416, 150);
            button2.Name = "button2";
            button2.Size = new Size(30, 23);
            button2.TabIndex = 4;
            button2.Text = "...";
            button2.UseVisualStyleBackColor = true;
            button2.Click += saveAs_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 132);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 3;
            label2.Text = "Output csv File";
            // 
            // button3
            // 
            button3.Location = new Point(370, 179);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 6;
            button3.Text = "Save";
            button3.UseVisualStyleBackColor = true;
            button3.Click += save_Click;
            // 
            // button4
            // 
            button4.Location = new Point(13, 179);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 7;
            button4.Text = "Reset";
            button4.UseVisualStyleBackColor = true;
            button4.Click += reset_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox24);
            groupBox1.Controls.Add(checkBox20);
            groupBox1.Controls.Add(checkBox10);
            groupBox1.Controls.Add(checkBox9);
            groupBox1.Controls.Add(checkBox7);
            groupBox1.Controls.Add(checkBox4);
            groupBox1.Controls.Add(checkBox12);
            groupBox1.Controls.Add(checkBox13);
            groupBox1.Controls.Add(checkBox16);
            groupBox1.Controls.Add(checkBox17);
            groupBox1.Controls.Add(checkBox18);
            groupBox1.Controls.Add(checkBox19);
            groupBox1.Controls.Add(checkBox22);
            groupBox1.Controls.Add(checkBox23);
            groupBox1.Controls.Add(checkBox11);
            groupBox1.Controls.Add(checkBox14);
            groupBox1.Controls.Add(checkBox15);
            groupBox1.Controls.Add(checkBox5);
            groupBox1.Controls.Add(checkBox6);
            groupBox1.Controls.Add(checkBox8);
            groupBox1.Controls.Add(checkBox3);
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Location = new Point(13, 208);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(606, 167);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Columns to Include";
            // 
            // checkBox24
            // 
            checkBox24.AutoSize = true;
            checkBox24.Location = new Point(324, 121);
            checkBox24.Name = "checkBox24";
            checkBox24.Size = new Size(104, 19);
            checkBox24.TabIndex = 27;
            checkBox24.Text = "Active Calories";
            checkBox24.UseVisualStyleBackColor = true;
            checkBox24.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox20
            // 
            checkBox20.AutoSize = true;
            checkBox20.Location = new Point(6, 45);
            checkBox20.Name = "checkBox20";
            checkBox20.Size = new Size(123, 19);
            checkBox20.TabIndex = 26;
            checkBox20.Text = "Resting Heart Rate";
            checkBox20.UseVisualStyleBackColor = true;
            checkBox20.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox10
            // 
            checkBox10.AutoSize = true;
            checkBox10.Location = new Point(179, 144);
            checkBox10.Name = "checkBox10";
            checkBox10.Size = new Size(71, 19);
            checkBox10.TabIndex = 25;
            checkBox10.Text = "Distance";
            checkBox10.UseVisualStyleBackColor = true;
            checkBox10.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox9
            // 
            checkBox9.AutoSize = true;
            checkBox9.Location = new Point(179, 119);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new Size(58, 19);
            checkBox9.TabIndex = 24;
            checkBox9.Text = "Floors";
            checkBox9.UseVisualStyleBackColor = true;
            checkBox9.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.Location = new Point(324, 95);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(68, 19);
            checkBox7.TabIndex = 23;
            checkBox7.Text = "Calories";
            checkBox7.UseVisualStyleBackColor = true;
            checkBox7.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(324, 144);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(54, 19);
            checkBox4.TabIndex = 22;
            checkBox4.Text = "Steps";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox12
            // 
            checkBox12.AutoSize = true;
            checkBox12.Enabled = false;
            checkBox12.Location = new Point(324, 45);
            checkBox12.Name = "checkBox12";
            checkBox12.Size = new Size(98, 19);
            checkBox12.TabIndex = 20;
            checkBox12.Text = "Highest SpO2";
            checkBox12.UseVisualStyleBackColor = true;
            checkBox12.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox13
            // 
            checkBox13.AutoSize = true;
            checkBox13.Enabled = false;
            checkBox13.Location = new Point(324, 70);
            checkBox13.Name = "checkBox13";
            checkBox13.Size = new Size(94, 19);
            checkBox13.TabIndex = 21;
            checkBox13.Text = "Lowest SpO2";
            checkBox13.UseVisualStyleBackColor = true;
            checkBox13.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox16
            // 
            checkBox16.AutoSize = true;
            checkBox16.Enabled = false;
            checkBox16.Location = new Point(179, 22);
            checkBox16.Name = "checkBox16";
            checkBox16.Size = new Size(129, 19);
            checkBox16.TabIndex = 19;
            checkBox16.Text = "Time Bellow Zone 1";
            checkBox16.UseVisualStyleBackColor = true;
            checkBox16.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox17
            // 
            checkBox17.AutoSize = true;
            checkBox17.Enabled = false;
            checkBox17.Location = new Point(179, 95);
            checkBox17.Name = "checkBox17";
            checkBox17.Size = new Size(104, 19);
            checkBox17.TabIndex = 18;
            checkBox17.Text = "Time in Zone 3";
            checkBox17.UseVisualStyleBackColor = true;
            checkBox17.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox18
            // 
            checkBox18.AutoSize = true;
            checkBox18.Enabled = false;
            checkBox18.Location = new Point(6, 95);
            checkBox18.Name = "checkBox18";
            checkBox18.Size = new Size(121, 19);
            checkBox18.TabIndex = 16;
            checkBox18.Text = "Lowest Heart Rate";
            checkBox18.UseVisualStyleBackColor = true;
            checkBox18.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox19
            // 
            checkBox19.AutoSize = true;
            checkBox19.Enabled = false;
            checkBox19.Location = new Point(6, 70);
            checkBox19.Name = "checkBox19";
            checkBox19.Size = new Size(125, 19);
            checkBox19.TabIndex = 14;
            checkBox19.Text = "Highest Heart Rate";
            checkBox19.UseVisualStyleBackColor = true;
            checkBox19.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox22
            // 
            checkBox22.AutoSize = true;
            checkBox22.Enabled = false;
            checkBox22.Location = new Point(179, 45);
            checkBox22.Name = "checkBox22";
            checkBox22.Size = new Size(104, 19);
            checkBox22.TabIndex = 11;
            checkBox22.Text = "Time in Zone 1";
            checkBox22.UseVisualStyleBackColor = true;
            checkBox22.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox23
            // 
            checkBox23.AutoSize = true;
            checkBox23.Enabled = false;
            checkBox23.Location = new Point(179, 70);
            checkBox23.Name = "checkBox23";
            checkBox23.Size = new Size(104, 19);
            checkBox23.TabIndex = 13;
            checkBox23.Text = "Time In Zone 2";
            checkBox23.UseVisualStyleBackColor = true;
            checkBox23.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox11
            // 
            checkBox11.AutoSize = true;
            checkBox11.Location = new Point(438, 95);
            checkBox11.Name = "checkBox11";
            checkBox11.Size = new Size(130, 19);
            checkBox11.TabIndex = 10;
            checkBox11.Text = "Minutes Very Active";
            checkBox11.UseVisualStyleBackColor = true;
            checkBox11.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox14
            // 
            checkBox14.AutoSize = true;
            checkBox14.Location = new Point(438, 45);
            checkBox14.Name = "checkBox14";
            checkBox14.Size = new Size(124, 19);
            checkBox14.TabIndex = 6;
            checkBox14.Text = "Minutes Sedentary";
            checkBox14.UseVisualStyleBackColor = true;
            checkBox14.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox15
            // 
            checkBox15.AutoSize = true;
            checkBox15.Location = new Point(438, 70);
            checkBox15.Name = "checkBox15";
            checkBox15.Size = new Size(136, 19);
            checkBox15.TabIndex = 7;
            checkBox15.Text = "Minutes Fairly Active";
            checkBox15.UseVisualStyleBackColor = true;
            checkBox15.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Enabled = false;
            checkBox5.Location = new Point(324, 22);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(100, 19);
            checkBox5.TabIndex = 5;
            checkBox5.Text = "Average SpO2";
            checkBox5.UseVisualStyleBackColor = true;
            checkBox5.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Enabled = false;
            checkBox6.Location = new Point(6, 121);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(135, 19);
            checkBox6.TabIndex = 4;
            checkBox6.Text = "Heart Rate Variability";
            checkBox6.UseVisualStyleBackColor = true;
            checkBox6.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox8
            // 
            checkBox8.AutoSize = true;
            checkBox8.Enabled = false;
            checkBox8.Location = new Point(438, 120);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(86, 19);
            checkBox8.TabIndex = 2;
            checkBox8.Text = "Sleep Score";
            checkBox8.UseVisualStyleBackColor = true;
            checkBox8.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(438, 20);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(144, 19);
            checkBox3.TabIndex = 3;
            checkBox3.Text = "Minutes Lightly Active";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Enabled = false;
            checkBox2.Location = new Point(6, 144);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(127, 19);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "Average Heart Rate";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += includeCol_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Enabled = false;
            checkBox1.Location = new Point(6, 20);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(135, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Active Zone Minutes";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += includeCol_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listView1);
            groupBox2.Location = new Point(451, 14);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(168, 198);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Column Order";
            // 
            // listView1
            // 
            listView1.AllowDrop = true;
            listView1.AutoArrange = false;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(6, 17);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.ShowGroups = false;
            listView1.Size = new Size(155, 175);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            listView1.ItemDrag += listView1_ItemDrag;
            listView1.DragDrop += listView1_DragDrop;
            listView1.DragEnter += listView1_DragEnter;
            listView1.DragOver += listView1_DragOver;
            // 
            // columnHeader1
            // 
            columnHeader1.Width = 1000;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 61);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 10;
            label3.Text = "From";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Days", "Weeks", "Months" });
            comboBox1.Location = new Point(94, 58);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(93, 23);
            comboBox1.TabIndex = 11;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(52, 58);
            maskedTextBox1.Mask = "000";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.PromptChar = ' ';
            maskedTextBox1.Size = new Size(36, 23);
            maskedTextBox1.TabIndex = 13;
            maskedTextBox1.ValidatingType = typeof(int);
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(94, 179);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(270, 23);
            progressBar1.TabIndex = 14;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(148, 132);
            label4.Name = "label4";
            label4.Size = new Size(298, 15);
            label4.TabIndex = 15;
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(11, 90);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(72, 15);
            linkLabel1.TabIndex = 17;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Date Format";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(94, 87);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(137, 23);
            textBox3.TabIndex = 18;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Checked = false;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(256, 60);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.ShowCheckBox = true;
            dateTimePicker2.Size = new Size(118, 23);
            dateTimePicker2.TabIndex = 20;
            dateTimePicker2.Value = new DateTime(2023, 8, 12, 19, 29, 29, 0);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(196, 64);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 21;
            label5.Text = "OR Since";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(631, 387);
            Controls.Add(label5);
            Controls.Add(dateTimePicker2);
            Controls.Add(textBox3);
            Controls.Add(linkLabel1);
            Controls.Add(label4);
            Controls.Add(progressBar1);
            Controls.Add(maskedTextBox1);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fitbit Google Takeout Converter";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button2;
        private Label label2;
        private Button button3;
        private Button button4;
        private GroupBox groupBox1;
        private CheckBox checkBox1;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox11;
        private CheckBox checkBox14;
        private CheckBox checkBox15;
        private CheckBox checkBox8;
        private CheckBox checkBox10;
        private CheckBox checkBox12;
        private CheckBox checkBox13;
        private CheckBox checkBox16;
        private CheckBox checkBox17;
        private CheckBox checkBox18;
        private CheckBox checkBox19;
        private CheckBox checkBox21;
        private CheckBox checkBox22;
        private CheckBox checkBox23;
        private GroupBox groupBox2;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private Label label3;
        private ComboBox comboBox1;
        private MaskedTextBox maskedTextBox1;
        private ProgressBar progressBar1;
        private Label label4;
        private CheckBox checkBox4;
        private CheckBox checkBox9;
        private CheckBox checkBox7;
        private CheckBox checkBox20;
        private CheckBox checkBox24;
        private LinkLabel linkLabel1;
        private TextBox textBox3;
        private DateTimePicker dateTimePicker2;
        private Label label5;
    }
}