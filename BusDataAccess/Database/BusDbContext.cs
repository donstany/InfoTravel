using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusDataAccess.Database
{
    public class BusDbContext : DbContext
    {
        public DbSet<BusPersonTable> Persons { get; set; }       

        public BusDbContext(DbContextOptions<BusDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         //   modelBuilder.Entity<BusPersonTable>().Property(p => p.Id).UseOracleIdentityColumn();
        }
    }
}
