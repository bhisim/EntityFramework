using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp.Models
{
    public class CrudAppDbContext : DbContext  //Ctrl + . ya bas
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CrudApp;uid=sa;pwd=123");
        }

        public DbSet<User> Kullanici { get; set; }  // db de tablo olduğunu burda söylüyorsun

        public DbSet<Categories> Kategori { get; set; }

        public DbSet<Shippers> Nakliyeci { get; set; }

        public DbSet<Customer> Musteri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>()
                        .Property(c => c.Name)
                        .HasColumnName("UserName")
                        .HasMaxLength(20);


            modelBuilder.Entity<Shippers>()
                        .Property(c => c.Name) // hangi property'ye özellik
                        .HasColumnName("ShipperName");

            modelBuilder.Entity<User>()
                        .Property(c => c.IsLock) // hangi property'ye özellik
                        .HasDefaultValue(false);


            modelBuilder.Entity<Customer>()
                        .Property(c => c.Name)
                        .HasColumnName("CompanyName")
                        .HasMaxLength(50);

            modelBuilder.Entity<Customer>()
                        .Property(c => c.ContactPhone)
                        .HasMaxLength(11);
        }
    }
}
