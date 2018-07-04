using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manulife.DNC.MSAD.NB.NoticeService.Models
{
    public class HealthMessage
    {
        public string Node { get; set; }
        public string ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string CheckID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Output { get; set; }
    }
}
