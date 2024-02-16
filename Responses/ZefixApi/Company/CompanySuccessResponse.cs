using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZefixTest.Responses.ZefixApi.Company
{
    public class CompanySuccessResponse
    {
        public string name { get; set; }
        public string chid { get; set; }
        public string legalSeat { get; set; }
        public string sogcDate { get; set; }
        public LegalForm legalForm { get; set; }
        public Address address { get; set; }
    }
}
