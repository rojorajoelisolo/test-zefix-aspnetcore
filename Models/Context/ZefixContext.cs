using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZefixTest.Models.Context
{
    public class ZefixContext : DbContext
    {
        public ZefixContext(DbContextOptions<ZefixContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
    }
}
