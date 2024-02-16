using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZefixTest.Interfaces.Repositories;
using ZefixTest.Models;
using ZefixTest.Models.Context;

namespace ZefixTest.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(ZefixContext _zefixContext) : base(_zefixContext) { }

        public async Task<Company> GetCompanyByChid(string chid)
        {
            return await _zefixContext.Companies
                   .Where(s => s.Chid == chid)
                   .FirstOrDefaultAsync();
        }
    }
}
