using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZefixTest.Models
{
    public class Company
    {
        public long Id { get; set; } 
        public string Name { get; set; }
        public string Chid { get; set; }
        public string LegalSeat { get; set; }
        public DateTime LastModification { get; set; }
        public string LegalForm { get; set; }
        public string Address { get; set; }
    }
}
