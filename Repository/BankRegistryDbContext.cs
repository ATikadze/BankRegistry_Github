using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    using Domain;

    public class BankRegistryDbContext : DbContext
    {
        public BankRegistryDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BankRegistryDbContext, Migrations.Configuration>());
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<ContactPerson> ContactPersons { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
