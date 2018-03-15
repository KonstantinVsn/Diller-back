using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Diller.Models
{
    public class DillerContext : DbContext
    {
        public DillerContext (DbContextOptions<DillerContext> options)
            : base(options)
        {
        }

        public DbSet<AutoBrand> AutoBrand { get; set; }
    }
}
