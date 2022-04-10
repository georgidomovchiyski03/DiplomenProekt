using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class ShopContext : DbContext
    {
        public DbSet<BulkProduct> BulkProducts { get; set; }

        public DbSet<PackegedProduct> PackegedProducts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Admin> Admins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-3I9S485\SQLEXPRESS;Database=Butchers;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
