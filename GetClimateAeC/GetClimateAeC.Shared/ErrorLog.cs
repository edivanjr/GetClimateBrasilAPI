using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetClimateAeC.Shared
{
    public class ErrorLog
    {
        public Guid Id { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime Date { get; set; }
    }
}
