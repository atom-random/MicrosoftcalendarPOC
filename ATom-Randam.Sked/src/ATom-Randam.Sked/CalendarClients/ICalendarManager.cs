using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATom_Randam.Sked.CalendarClients
{
    public interface ICalendarManager
    {
        Task<AccessTokenResponse> GetAccessToken(AccessTokenRequest request);
        Task<IEnumerable<Calendar>> GetCalendarDetails(string accessToken);
        AccessTokenResponse RefreshAccessToken();
    }
} 