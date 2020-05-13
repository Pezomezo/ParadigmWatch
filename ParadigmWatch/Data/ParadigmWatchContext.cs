using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParadigmWatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmWatch.Data
{
    public class ParadigmWatchContext : IdentityDbContext
    {
        public ParadigmWatchContext(DbContextOptions<ParadigmWatchContext> options) : base(options) { }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Watch> Watches { get; set; }
        public DbSet<WatchPart> MyProperty { get; set; }
        public DbSet<StandardShader> StandardShaders { get; set; }
        public DbSet<TextMap> TextMaps { get; set; }
        public DbSet<Texture> Textures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Invoice>().ToTable("Invoice");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItem");
            modelBuilder.Entity<Watch>().ToTable("Watch");
            modelBuilder.Entity<WatchPart>().ToTable("WatchPart");
            modelBuilder.Entity<StandardShader>().ToTable("StandardShader");
            modelBuilder.Entity<Texture>().ToTable("Texture");
            modelBuilder.Entity<TextMap>().ToTable("TextMap");
        }
    }
}
