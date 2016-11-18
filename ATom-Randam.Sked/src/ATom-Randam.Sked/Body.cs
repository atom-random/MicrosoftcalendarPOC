using Newtonsoft.Json;

namespace ATom_Randam.Sked.CalendarClients.Microsoft
{
    public class Body
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("contentType")]
        public string ContentType { get; set; }
    }
}