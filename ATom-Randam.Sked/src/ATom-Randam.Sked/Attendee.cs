using Newtonsoft.Json;

namespace ATom_Randam.Sked.CalendarClients.Microsoft
{
    public class Attendee
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("status")]
        public ResponseStatus Status { get; set; }
    }
}