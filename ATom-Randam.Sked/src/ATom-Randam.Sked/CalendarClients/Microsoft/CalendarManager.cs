using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ATom_Randam.Sked.CalendarClients.Microsoft
{
    public class CalendarManager : ICalendarManager
    {
        public CalendarManager(IConfigurationRoot configure)
        {
            _configure = configure;
        }

        private const string _acessTokenUrl = "/common/oauth2/v2.0/token";
        private IConfigurationRoot _configure;

        public async Task<AccessTokenResponse> GetAccessToken(AccessTokenRequest request)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            
            httpClient.BaseAddress = new Uri("https://login.microsoftonline.com");
            request.RedirectUrl = "https://localhost:44314/Calendar/MicrosoftAuthTokenCallback";
            request.GrantType = "authorization_code";
            request.ClientID = _configure.GetValue<string>("Microsoft:ClientID");
            request.Secret = _configure.GetValue<string>("Microsoft:Secret");
            
            //TODO: Move most of this logic to base class
            //TODO: add logging
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("client_id",$"{request.ClientID}"),
                new KeyValuePair<string, string>("client_secret",$"{request.Secret}"),
                new KeyValuePair<string, string>("scope","https://graph.microsoft.com/calendars.read"),
                new KeyValuePair<string, string>("code",$"{request.Code}"),
                new KeyValuePair<string, string>("redirect_uri","https://localhost:44314/Calendar/MicrosoftAuthTokenCallback")
            });
            var accessTokenResponse = await
                httpClient.PostAsync(_acessTokenUrl, content);

             AccessTokenResponse accessToken = null;
            if (accessTokenResponse.IsSuccessStatusCode)
            {
                var t = new JsonMediaTypeFormatter();
                t.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
                accessToken = await accessTokenResponse.Content.ReadAsAsync<AccessTokenResponse>(new List<MediaTypeFormatter>
                {
                    t
                });

            }else
            {
                var t = await accessTokenResponse?.Content?.ReadAsStringAsync();
            }

            return accessToken;
        }
        public AccessTokenResponse RefreshAccessToken()
        {
            return new AccessTokenResponse();
        }

        public async Task<IEnumerable<Calendar>> GetCalendarDetails(string accessToken)
        {

            IEnumerable<Calendar> calendarDetails = new List<Calendar>();
            
            HttpClient httpClient = new HttpClient();
            //accessToken = "eyJ0eXAiOiJKV1QiLCJub25jZSI6IkFRQUJBQUFBQUFEUk5ZUlEzZGhSU3JtLTRLLWFkcENKVG0tS25HM2RKMUNuWERUSnFmQV9jeFVHZGNna3BGN1RzOGl0RUtaRXNVamkxTmJYNzFPbHQ1RWlBT3RGZHY4RkJpdDd5SFRGNjhKSGhOQ2YwMExqTWlBQSIsImFsZyI6IlJTMjU2IiwieDV0IjoiSTZvQnc0VnpCSE9xbGVHclYyQUpkQTVFbVhjIiwia2lkIjoiSTZvQnc0VnpCSE9xbGVHclYyQUpkQTVFbVhjIn0.eyJhdWQiOiJodHRwczovL2dyYXBoLm1pY3Jvc29mdC5jb20iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC82YjdlZDEyNi03YjUyLTQxMzktOTVkYy1lYjFjOTJiZTA0MjAvIiwiaWF0IjoxNDc5MDcxNzg1LCJuYmYiOjE0NzkwNzE3ODUsImV4cCI6MTQ3OTA3NTY4NSwiYWNyIjoiMSIsImFtciI6WyJwd2QiLCJtZmEiXSwiYXBwX2Rpc3BsYXluYW1lIjoiU2tlZCIsImFwcGlkIjoiYjU4YTQzMTUtY2E1Yy00OWMxLWJkZjItODlhMjNkMDg3MjkyIiwiYXBwaWRhY3IiOiIxIiwiZmFtaWx5X25hbWUiOiJCcmFkbGV5IiwiZ2l2ZW5fbmFtZSI6IkFkYW0iLCJpcGFkZHIiOiI1MS42Ljk1LjMyIiwibmFtZSI6IkFkYW0gQnJhZGxleSIsIm9pZCI6ImM3OTcyOWQ5LWFlNDQtNDM4Ny04ZDU0LTZjNDVhZTkyNjZiZiIsIm9ucHJlbV9zaWQiOiJTLTEtNS0yMS00MDg4Njk3OTctMTc1Njc4OTQzMS0zMjgzODU3ODgyLTI3ODEiLCJwbGF0ZiI6IjMiLCJwdWlkIjoiMTAwMzAwMDA5NkNEMTY0MyIsInNjcCI6IkNhbGVuZGFycy5SZWFkIENhbGVuZGFycy5SZWFkLlNoYXJlZCIsInNpZ25pbl9zdGF0ZSI6WyJrbXNpIl0sInN1YiI6Imx3eFAzY2ZDQkZ0S3hFbWNHNjFJdy1JRUY5d2E0VHhrWUxYeDIzY1FLSzQiLCJ0aWQiOiI2YjdlZDEyNi03YjUyLTQxMzktOTVkYy1lYjFjOTJiZTA0MjAiLCJ1bmlxdWVfbmFtZSI6IkFkYW0uQnJhZGxleUBydW5wYXRoLmNvbSIsInVwbiI6IkFkYW0uQnJhZGxleUBydW5wYXRoLmNvbSIsInZlciI6IjEuMCJ9.TAHGEFF_9jzh6Mcuttq0Db7Q81A0X0_MMXvhRKgMCxtleqg97q4G5_XeVmAbWKf3p7N7aVtIXfeTZzZnHmn210LH3_3zOWPKDR1UZiUkQjZtlVt2hXNGtjatZImzhKv4_PDrx4LLDEPzZC7xyQBq2902pMlOFdiIqq9hYlChFb8A7vmA9YoUIOB53umIC7gVVJtyltfLxOweeJdXDZG1tUvAP5V5-6laAJc2b_jPqNM_3Ln1lAcySOGHzEUCZgp4Ir7j0C5NDjcz-cjHp9Zl4FwzfFdLSwviDryesGgjYbOjGM6M2l6eKDVtCt5NsqJVw2_q_k1lNExsRJzqeFgDQg";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            httpClient.BaseAddress = new Uri("https://graph.microsoft.com");
            //var calendarsResponse = await httpClient.GetAsync("/v1.0/me/calendars");

            //if (calendarsResponse.IsSuccessStatusCode)
            //{
            //   //var calendars = await calendarsResponse.Content.ReadAsAsync<CalenderLists>();

               // foreach (var calendar in calendars.CalendarList)
               // {
                    var calendarResponse = await httpClient.GetAsync($"/v1.0/me/events");

                    if (calendarResponse.IsSuccessStatusCode)
                    {
                       var results = await calendarResponse.Content.ReadAsAsync<CalendarResult>(); 
                    }
                //}
       //     }

            

            return calendarDetails; 
        }
    }
}
