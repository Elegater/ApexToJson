using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexToJson
{
    class Apex
    {
        public Apex(string id, string ship, string rank, string apexName, string type, string description, string cost, string dps, string mainType, string aura, string zen, string video, string imageName)
        {
            this.id = id;
            this.ship = ship;
            this.rank = rank;
            this.apexName = apexName;
            this.type = type;
            this.description = description;
            this.cost = cost;
            this.dps = dps;
            this.mainType = mainType;
            this.aura = aura;
            this.zen = zen;
            this.video = video;
            this.imageName = imageName;
        }

        public string id { get; set; }
        public string ship { get; set; }
        public string rank { get; set; }
        public string apexName { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string cost { get; set; }
        public string dps { get; set; }
        public string mainType { get; set; }
        public string aura { get; set; }
        public string zen { get; set; }
        public string video { get; set; }
        public string imageName { get; set; }

    }
}
