using Microsoft.EntityFrameworkCore;
using ProvaFinale_week7_LIONETTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFinale_week7_LIONETTO
{
    public class Context :DbContext
    {
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Polizza> Polizze { get; set; }
        public Context() :base () {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assicurazioni;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Cliente>(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration<Polizza>(new PolizzaConfiguration());
        }
    }
}
