using System.Globalization;

namespace Takeout.Fitbit.Parser.DataTypes
{
    internal class BaseWithDateTime
    {
        public string dateTime { get; set; }
        public DateTime Date => DateTime.ParseExact(dateTime, "MM/dd/yy HH:mm:ss", CultureInfo.InvariantCulture).StartOfDay();
        public DateTime DateTime => DateTime.ParseExact(dateTime, "MM/dd/yy HH:mm:ss", CultureInfo.InvariantCulture);
    }
    internal class BaseWithStringValue : BaseWithDateTime
    {
        public string value { get; set; }
    }
    internal class BaseWithNestedValue<TValue> : BaseWithDateTime
    {
        public TValue value { get; set; }
    }
}
