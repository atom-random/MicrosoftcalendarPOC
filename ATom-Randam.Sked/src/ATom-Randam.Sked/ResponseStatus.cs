using Newtonsoft.Json;

namespace ATom_Randam.Sked.CalendarClients.Microsoft
{
    public class ResponseStatus
    {
        [JsonProperty("response")]
        public string Response { get; set; }
        /*The response type: None = 0, Organizer = 1, TentativelyAccepted = 2, Accepted = 3, Declined = 4, NotResponded = 5. */
    }
}