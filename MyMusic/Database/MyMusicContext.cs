using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Database
{
    public class MyMusicContext : DbContext
    {
        public MyMusicContext()
        {
        }
        public MyMusicContext(DbContextOptions<MyMusicContext> options) 
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=MyMusicDB;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Songs>()
                .HasOne<Category>(s => s.Category)
                .WithMany(g => g.Songs)
                .HasForeignKey(s => s.CategoryId);

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Songs> Songs { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
