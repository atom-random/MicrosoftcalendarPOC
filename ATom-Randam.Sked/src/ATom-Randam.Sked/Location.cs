using Newtonsoft.Json;

namespace ATom_Randam.Sked.CalendarClients.Microsoft
{
    public class Location
    {

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }
}