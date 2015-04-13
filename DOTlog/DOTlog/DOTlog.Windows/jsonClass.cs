using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DOTlog
{
    [DataContract]
    public class jsonClass
    {
        [DataMember]
        public string airport
        {
            get;
            set;
        }
        [DataMember]
        public string category
        {
            get;
            set;
        }
        [DataMember]
        public string timeOfEvent
        {
            get;
            set;
        }
        [DataMember]
        public string eventDescription
        {
            get;
            set;
        }
        [DataMember]
        public bool includeInReport
        {
            get;
            set;
        }

        public jsonClass()
        {

        }

        public jsonClass(   string Airport, 
                            string Category, 
                            string TimeOfEvent, 
                            string EventDescription,
                            bool IncludeInReport)
        {
            airport = Airport;
            category = Category;
            timeOfEvent = TimeOfEvent;
            eventDescription = EventDescription;
            includeInReport = IncludeInReport;
        }
    }
}
