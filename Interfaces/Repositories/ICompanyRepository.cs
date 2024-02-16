using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZefixTest.Models;

namespace ZefixTest.Interfaces.Repositories
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        Task<Company> GetCompanyByChid(string chid);
    }
}
