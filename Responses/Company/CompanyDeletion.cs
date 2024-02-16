using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZefixTest.Responses.Base;
using CompanyModel = ZefixTest.Models.Company;

namespace ZefixTest.Responses.Company
{
    public class CompanyDeletionResponse : AbstractResponse
    {
        public bool Deleted { get; set; }
    }
}
