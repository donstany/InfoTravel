using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDataAccess.Database
{

    public class FlightDbContext : DbContext
    {
        public DbSet<FlightPersonTable> FlightPersons { get; set; }

        public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  modelBuilder.Entity<PersonTable>().Property(p => p.Id).UseOracleIdentityColumn();
        }
    }
   
}
