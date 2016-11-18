using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ATom_Randam.Sked.CalendarClients;

namespace ATom_Randam.Sked.Controllers
{
    public class CalendarController : Controller
    {
        private ICalendarManager _calendarManager;
        public CalendarController(ICalendarManager calandarManager)
        {
            _calendarManager = calandarManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var calenders = await _calendarManager.GetCalendarDetails("");

            return View();
        }

        [HttpGet]
        public async Task MicrosoftAuthTokenCallback(string code)
            {
            try
            {
                var accessToken = await _calendarManager.GetAccessToken(new AccessTokenRequest
                {
                    Code = code
                });
                var calenders = await _calendarManager.GetCalendarDetails(accessToken.AccessToken);
                
            }
            catch(Exception e)
            {
                string t = "t"+e.Message;
            }            
        }
    }
}
