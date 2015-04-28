using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DOTlogAPP
{
    [DataContract]
    public class eventType
    {
        
        
        [DataMember(Order = 0)]
        public string FAA_CODE { get; set; }
        
        [DataMember(Order = 1)]
        public string CATEGORY_TITLE { get; set; }
        
        [DataMember(Order =2)]
        public bool IN_WEEKLY_REPORT { get; set; }

        [DataMember(Order = 3)]
        public string EVENT_TIME { get; set; }

        [DataMember(Order = 4)]
        public string EVENT_TEXT { get; set; }
        

        public eventType(){}

        public eventType(   string Airport,
                            string Category,
                            bool IncludeInReport,
                            string TimeOfEvent,
                            string EventDescription
                            )
        {            
            FAA_CODE = Airport;
            CATEGORY_TITLE = Category;
            IN_WEEKLY_REPORT = IncludeInReport;
            EVENT_TIME = TimeOfEvent;
            EVENT_TEXT = EventDescription;            
        }
    }

    public class eventList
    {
        public List<eventType> EVENTS { get; set; }

        public eventList()
        {
            EVENTS = new List<eventType>();
        }

    }

}