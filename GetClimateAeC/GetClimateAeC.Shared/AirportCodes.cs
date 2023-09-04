using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetClimateAeC.Shared
{
    public class AirportCodes
    {
        public Guid Id { get; set; }
        public string Acronym { get; set; }
        public string Airport { get; set; }
        public string State { get; set; }
        public string LinkAirportClimateLocal { get; set; }
        public string LinkAirportClimateBrasilAPI { get; set; }
    }
}
