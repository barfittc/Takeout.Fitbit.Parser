using System.Text;

namespace Takeout.Fitbit.Parser
{
    internal class Csv
    {
        private readonly Data data;
        private readonly string[] columns;
        public Csv(Data data, string[] columns)
        {
            this.data = data;
            this.columns = columns;
        }

        public async Task Save(string file)
        {

            StringBuilder sb = new StringBuilder();
            string[][] saveData = await this.GetSavableData();

            int rowCount = saveData[0].Length;
            int columnCount = saveData.Length;

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    string cell = saveData[columnIndex][rowIndex] ?? string.Empty;
                    if (cell.Contains(","))
                    {
                        cell = $"\"{cell}\"";
                    }
                    sb.Append(cell);
                    if (columnIndex < columnCount - 1)
                    {
                        sb.Append(",");
                    }
                }
                sb.Append(Environment.NewLine);
            }
            if(File.Exists(file))
            {
                File.Delete(file);
            }
            await File.WriteAllTextAsync(file, sb.ToString());
        }
        private async Task<string[][]> GetSavableData ()
        {
            var result = new string[columns.Length][];
            for(int i = 0; i < columns.Length; i ++)
            {
                var columnData = await data.GetData(columns[i]);
                result[i] = new string[columnData.Length + 1];
                result[i][0] = columns[i];
                for (int x = 0; x < columnData.Length; x++)
                {
                    result[i][x + 1] = columnData[x];
                }
            }
            return result;
        }
    }
}
