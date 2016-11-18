using Newtonsoft.Json;
using System.Collections.Generic;

namespace ATom_Randam.Sked.CalendarClients.Microsoft
{
    public class CalendarEvent
    {
        [JsonProperty("attendees")]
        public IList<Attendee> Attendees { get; set; }
        [JsonProperty("body")]
        public Body Body { get; set; }
        [JsonProperty("bodyPreview")]
        public string BodyPreview { get; set; }
        [JsonProperty("categories")]
        public IList<string> Categories { get; set; }
        [JsonProperty("createdDateTime")]
        public string CreatedDateTime { get; set; }
        [JsonProperty("iCalUId")]
        public string ICalUId { get; set; }
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("importance")]
        public string Importance { get; set; }
        [JsonProperty("isAllDay")]
        public bool IsAllDay { get; set; }
        [JsonProperty("isCancelled")]
        public bool IsCancelled { get; set; }
        [JsonProperty("isOrganizer")]
        public bool IsOrganizer { get; set; }
        [JsonProperty("isReminderOn")]
        public bool IsReminderOn { get; set; }
        [JsonProperty("location")]
        public Location Location { get; set; }
        [JsonProperty("end")]
        public DateTimeZone End { get; set; }
        [JsonProperty("start")]
        public DateTimeZone Start { get; set; }
        [JsonProperty("originalEndTimeZone")]
        public string OriginalEndTimeZone { get; set; }
        [JsonProperty("subject")]
        public string Subject { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}

/*
 * 
  "attendees": [{"@odata.type": "microsoft.graph.attendee"}],
  "body": {"@odata.type": "microsoft.graph.itemBody"},
  "bodyPreview": "string",
  "categories": ["string"],
  "changeKey": "string",
  "createdDateTime": "String (timestamp)",
  "end": {"@odata.type": "microsoft.graph.dateTimeTimeZone"},
  "hasAttachments": true,
  "iCalUId": "string",
  "id": "string (identifier)",
  "importance": "String",
  "isAllDay": true,
  "isCancelled": true,
  "isOrganizer": true,
  "isReminderOn": true,
  "lastModifiedDateTime": "String (timestamp)",
  "location": {"@odata.type": "microsoft.graph.location"},
  "onlineMeetingUrl": "string",
  "organizer": {"@odata.type": "microsoft.graph.recipient"},
  "originalEndTimeZone": "string",
  "originalStart": "String (timestamp)",
  "originalStartTimeZone": "string",
  "recurrence": {"@odata.type": "microsoft.graph.patternedRecurrence"},
  "reminderMinutesBeforeStart": 1024,
  "responseRequested": true,
  "responseStatus": {"@odata.type": "microsoft.graph.responseStatus"},
  "sensitivity": "String",
  "seriesMasterId": "string",
  "showAs": "String",
  "start": {"@odata.type": "microsoft.graph.dateTimeTimeZone"},
  "subject": "string",
  "type": "String",
  "webLink": "string",

  "attachments": [ { "@odata.type": "microsoft.graph.attachment" } ],
  "calendar": { "@odata.type": "microsoft.graph.calendar" },
  "instances": [ { "@odata.type": "microsoft.graph.event" }]

}
*/