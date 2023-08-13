using System.Reflection.Metadata;
using Takeout.Fitbit.Parser.DataTypes;

namespace Takeout.Fitbit.Parser
{
    internal class Data
    {
        private readonly string dateFormat;
        private readonly DirectoryInfo source;
        private readonly DateTime[] dates;
        private readonly DateTime from;
        public  Data(DirectoryInfo source, DateTime from, string dateFormat)
        {
            this.source = source;
            this.from = from;
            this.dateFormat = dateFormat;

            this.dates = new DateTime[new TimeSpan(DateTime.Now.Ticks - from.Ticks).Days];
            for (int i = 0; i < this.dates.Length; i++)
            {
                this.dates[i] = from.AddDays(i);
            }
        }

        public async Task<string[]> GetData(string column)
        {
            switch(column)
            {
                case "Date": return DateColumn();

                case "Active Zone Minutes": return new string[this.dates.Length];
                case "Resting Heart Rate": return await RHR();
                case "Highest Heart Rate": return new string[this.dates.Length];
                case "Lowest Heart Rate": return new string[this.dates.Length];
                case "Heart Rate Variability": return new string[this.dates.Length];
                case "Average Heart Rate": return new string[this.dates.Length];

                case "Time Bellow Zone 1": return new string[this.dates.Length];
                case "Time in Zone 1": return new string[this.dates.Length];
                case "Time in Zone 2": return new string[this.dates.Length];
                case "Time in Zone 3": return new string[this.dates.Length];
                case "Floors": return await Floors();
                case "Distance": return await simpleInt("distance-");

                case "Average SpO2": return new string[this.dates.Length];
                case "Highest SpO2": return new string[this.dates.Length];
                case "Lowest SpO2": return new string[this.dates.Length];
                case "Calories": return await simpleFloat("calories-");
                case "Active Calories": return await ActiveCalories();
                case "Steps": return await simpleInt("steps-");

                case "Minutes Lightly Active": return await simpleInt("lightly_active_minutes-");
                case "Minutes Sedentary": return await simpleInt("sedentary_minutes-");
                case "Minutes Fairly Active": return await simpleInt("moderately_active_minutes-");
                case "Minutes Very Active": return await simpleInt("very_active_minutes-");
                case "Sleep Score": return new string[this.dates.Length];
            }
            return new string[this.dates.Length];
        }

        private string[] DateColumn()
        {
            return this.dates.Select(_ => _.ToString(this.dateFormat)).ToArray();
        }

        private Task<string[]> simpleInt(string filePrefix)
            => simpleValue<int>(filePrefix, 0, (value, organized) => int.Parse(value) + organized, (organized) => organized.ToString());

        private Task<string[]> simpleFloat(string filePrefix)
            => simpleValue<float>(filePrefix, 0, (value, organized) => float.Parse(value) + organized, (organized) => Math.Round(organized).ToString());
        
        private Task<string[]> RHR()
            => complexValue<RestingHeartRate, float>("resting_heart_rate-", 0, (value, organized) => value.value + organized, (organized) => Math.Round(organized).ToString());

        private async Task<string[]> simpleValue<TSimple>(string filePrefix, TSimple defaultValue, Func<string, TSimple, TSimple> parse, Func<TSimple, string> stringify)
        {
            Dictionary<DateTime, TSimple> organized = new Dictionary<DateTime, TSimple>();
            foreach (BaseWithStringValue data in (await source.ParseJsonFiles<BaseWithStringValue>(filePrefix)).Where(c => c.Date >= this.from))
            {
                if (!organized.ContainsKey(data.Date))
                    organized[data.Date] = defaultValue;
                organized[data.Date] = parse(data.value, organized[data.Date]);
            }
            return this.dates.Select(date => (organized.ContainsKey(date) ? stringify(organized[date]) : string.Empty)).ToArray();
        }

        private async Task<string[]> complexValue<TValue,TSimple>(string filePrefix, TSimple defaultValue, Func<TValue, TSimple, TSimple> parse, Func<TSimple, string> stringify)
        {
            Dictionary<DateTime, TSimple> organized = new Dictionary<DateTime, TSimple>();
            foreach (BaseWithNestedValue<TValue> data in (await source.ParseJsonFiles<BaseWithNestedValue<TValue>>(filePrefix)).Where(c => c.Date >= this.from))
            {
                if (!organized.ContainsKey(data.Date))
                    organized[data.Date] = defaultValue;
                organized[data.Date] = parse(data.value, organized[data.Date]);
            }
            return this.dates.Select(date => (organized.ContainsKey(date) ? stringify(organized[date]) : string.Empty)).ToArray();
        }

        private async Task<string[]> ActiveCalories()
        {
            try
            {

            // need to calc sleeping range
            // then filter calories in that range.
            // get a ratio of what's left in the day away
            // then get total calories - ( sleep calories * sleepAwakeRatio)
            Dictionary<DateTime, (DateTime Sleep, DateTime Awake, long awakeRatio)> sleepTime = new Dictionary<DateTime, (DateTime, DateTime, long)>();
            Dictionary<DateTime, List<(DateTime When, float Burnt)>> dayOfCalories = new Dictionary<DateTime, List<(DateTime, float)>>();

            foreach (BaseWithStringValue data in (await source.ParseJsonFiles<BaseWithStringValue>("calories-")).Where(c => c.Date >= this.from))
            {
                if (!dayOfCalories.ContainsKey(data.Date))
                    dayOfCalories[data.Date] = new List<(DateTime When, float Burnt)>();
                dayOfCalories[data.Date].Add((data.DateTime, float.Parse(data.value)));
            }

            long dayTicks = TimeSpan.FromDays(1).Ticks;
            foreach (Sleep data in (await source.ParseJsonFiles<Sleep>("sleep-")).Where(c => c.Date >= this.from && c.mainSleep))
            {
                long sleepTotal = new TimeSpan(data.endTime.Ticks - data.startTime.Ticks).Ticks;
                sleepTime[data.Date] = (data.startTime, data.endTime, dayTicks / sleepTotal);
            }

            Dictionary<DateTime, float> organized = new Dictionary<DateTime, float>();
            foreach (var day in dayOfCalories.Keys)
            {
                var start = sleepTime[day].Sleep;
                var end = sleepTime[day].Awake;
                var ratio = sleepTime[day].awakeRatio;

                // calcuate all calories while sleeping
                // multiply by awakeRatio
                var basalMetabolicRate = dayOfCalories[day].Where(_ => _.When >= start && _.When <= end).Select(_ => _.Burnt).Sum() * ratio;
                var totalBurnt = dayOfCalories[day].Select(_ => _.Burnt).Sum();

                organized[day] = totalBurnt - basalMetabolicRate;
            }

            return this.dates.Select(date => (organized.ContainsKey(date) ? Math.Round(organized[date]).ToString() : string.Empty)).ToArray();
            }
            catch (Exception ex)
            {
                return new string[this.dates.Length];
            }
        }

        private async Task<string[]> Floors()
        {
            Dictionary<DateTime, (int floors,int prevousAltitude)> organized = new Dictionary<DateTime, (int floors, int prevousAltitude)>();
            
            foreach (BaseWithStringValue data in (await source.ParseJsonFiles<BaseWithStringValue>("altitude-")).Where(c => c.Date >= this.from))
            {
                var currentValue = int.Parse(data.value);

                if (!organized.ContainsKey(data.Date))
                    organized[data.Date] = (0, currentValue);

                if (organized[data.Date].prevousAltitude == currentValue)
                    continue;

                organized[data.Date] = (organized[data.Date].floors + 1, currentValue);
            }
            return this.dates.Select(date => (organized.ContainsKey(date) ? organized[date].floors.ToString() : string.Empty)).ToArray();
        }
    }
}
