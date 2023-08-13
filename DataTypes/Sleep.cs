using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Takeout.Fitbit.Parser.DataTypes
{
    internal class Sleep
    {
        public string dateOfSleep { get; set; }
        public DateTime Date => DateTime.ParseExact(dateOfSleep, "yyyy-MM-dd", CultureInfo.InvariantCulture).StartOfDay();
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public bool mainSleep { get; set; }
        
    }
}
