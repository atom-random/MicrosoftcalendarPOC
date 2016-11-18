using Newtonsoft.Json;

namespace ATom_Randam.Sked.CalendarClients
{
    public class AccessTokenResponse
    {
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        public string Scope { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty("id_token")]
        public string IdToken { get; set; }
    }
}
