using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Takeout.Fitbit.Parser.DataTypes
{
    internal class RestingHeartRate
    {
        public string dateTime { get; set; }
        public DateTime date => DateTime.ParseExact(dateTime, "MM/dd/yy", CultureInfo.InvariantCulture).StartOfDay();
        public float value { get; set; }
        public float error { get; set; }
    }
}
