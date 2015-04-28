using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTlogAPP
{
    public class airport
    {
        public string FAA_CODE { get; set; }
    }

    public class airportList
    {
        public List<airport> AIRPORTS { get; set; }
    }
    /*
    public class hub
    {
        public string HUB_NAME { get; set; }
    }

    public class hubList
    {
        public List<hub> HUBS { get; set; }
        public airportList AIRPORTS;
    }

    public class district
    {
        public string DISTRICT_NAME { get; set; }
    }

    public class districtList
    {
        public List<district> DISTRICTS { get; set; }
        public hubList HUBS { get; set; }
    }

    public class region
    {
        public string REGION_NAME { get; set; }
    }

    public class regionList
    {
        public List<region> REGIONS { get; set; }
        public districtList DISTRICTS;
    }
    */
}