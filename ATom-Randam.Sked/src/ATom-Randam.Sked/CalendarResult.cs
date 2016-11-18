using ATom_Randam.Sked.CalendarClients.Microsoft;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATom_Randam.Sked
{
    public class CalendarResult
    {
        [JsonProperty("value")]
        public IList<CalendarEvent> Values { get; set; }
    }
}
