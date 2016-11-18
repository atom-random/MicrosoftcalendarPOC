using Newtonsoft.Json;

namespace ATom_Randam.Sked.CalendarClients.Microsoft
{
    public class DateTimeZone
    {
        [JsonProperty("dateTime")]
        public string DateTime { get; set; }
        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }
    }
}