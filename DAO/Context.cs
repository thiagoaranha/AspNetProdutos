using DAO.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
        public class Context : DbContext
        {
            public Context()
                : base("name=dbprodutos")
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, DAO.Migrations.Configuration>("dbprodutos"));
            }

            public DbSet<Produto> Produtos { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }
}
