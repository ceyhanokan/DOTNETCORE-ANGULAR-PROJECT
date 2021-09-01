using Entities.TABLES;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFW.Context
{
    public class EF_DBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString: @"Server=localhost;Port=5432;Database=ODAKGISDB; User Id=postgres;Password=741852963;");
            //base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Immovable> Immovables { get; set; }
        public DbSet<Authorization> Authorizations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Entities.TABLES.TypeTBL> Types { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Neighbourhood> Neighbourhoods { get; set; }
    }
}
