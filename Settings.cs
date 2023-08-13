namespace Takeout.Fitbit.Parser
{
    public class Settings
    {
        public Dictionary<string, bool> Checked { get; set; } = new Dictionary<string, bool>();
        public Dictionary<string, int> Order { get; set; } = new Dictionary<string, int>();
        public int FromValue { get; set; } = 30;
        public string FromType { get; set; } = "Days";
        public string DateFormat { get; set; } = "yyyy-MM-dd";
    }
}
