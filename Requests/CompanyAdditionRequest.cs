using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZefixTest.Requests
{
    public class CompanyAdditionRequest
    {
        public string Name { get; set; }
        public string Chid { get; set; }
        public string Seat { get; set; }
        public string LastModification { get; set; }
        public string LegalForm { get; set; }
        public string Address { get; set; }
    }
}
