using System.Text.Json;

namespace Takeout.Fitbit.Parser
{
    internal static class Extensions
    {
        public static DateTime StartOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
        }
        public static DateTime StartOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        static Dictionary<string,IEnumerable<object>> cache = new Dictionary<string, IEnumerable<object>>();
        public static void ClearCache(this DirectoryInfo directory)
        {
            cache.Clear();
        }

        public static async Task<IEnumerable<TResult>> ParseJsonFiles<TResult>(this DirectoryInfo directory, string startsWith)
        {
            if (cache.ContainsKey(startsWith))
            {
                return cache[startsWith].Select(_ => (TResult)_);
            }
            var result = new List<TResult>();
            foreach (var file in directory.Allfiles(startsWith, "json"))
            {
                var text = await File.ReadAllTextAsync(file);
                if (string.IsNullOrEmpty(text)) text = "[]";
                var jsonData = JsonSerializer.Deserialize<List<TResult>>(text);
                result.AddRange(jsonData ?? new List<TResult>());
            }
            cache[startsWith] = result.Select(_ => (object)_);
            return result;
        }


        public static string[] Allfiles(this DirectoryInfo directory, string startsWith, string endWith)
        {
            return Directory.GetFiles(directory.FullName, $"{startsWith}*.{endWith}", SearchOption.AllDirectories);
        }

    }
}
