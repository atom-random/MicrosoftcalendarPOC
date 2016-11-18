using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATom_Randam.Sked.CalendarClients
{
    public class CalenderLists
    {
        [JsonProperty("value")]
        public IList<CalendarOverview> CalendarList { get; set; }

        public class CalendarOverview
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("id")]
            public long Id { get; set; }
        }
    }
}
