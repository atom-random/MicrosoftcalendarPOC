using Newtonsoft.Json;

namespace ATom_Randam.Sked.CalendarClients
{
    public class AccessTokenRequest
    {
        [JsonProperty("client_id")]
        public string ClientID { get; set; }
        [JsonProperty("client_secret")]
        public string Secret { get; set; }
        public string Code { get; set; }
        [JsonProperty("redirect_uri")]
        public string RedirectUrl { get; set; }
        [JsonProperty("grant_type")]
        public string GrantType { get; set; }
        
    }
}