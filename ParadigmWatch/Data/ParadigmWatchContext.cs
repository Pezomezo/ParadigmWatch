using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

            // Setting up many-to-many
            modelBuilder.Entity<WatchComponents>()
                .HasKey(key => new { key.WatchId, key.WatchPartId});
            modelBuilder.Entity<WatchComponents>()
            .HasOne(pt => pt.Watch)
            .WithMany(p => p.WatchComponents)
            .HasForeignKey(pt => pt.WatchId);

            modelBuilder.Entity<WatchComponents>()
                .HasOne(pt => pt.WatchPart)
                .WithMany(t => t.WatchComponents)
                .HasForeignKey(pt => pt.WatchPartId);

            modelBuilder.Entity<Texture>().HasData(
                new Texture() { Id = 1, TextureName = "Leather", TextureDesc = "This Leather makes you look rich&stuff", ImagePath = "Image/something", TexturePrice = 12.22m },
                new Texture() { Id = 2, TextureName = "Gekko", TextureDesc = "Feel the Gekko", ImagePath = "Image/something", TexturePrice = 15.22m },
                new Texture() { Id = 3, TextureName = "Crocodile", TextureDesc = "Wanna be the most badass person? try this then!", ImagePath = "Image/something", TexturePrice = 33.4m },
                new Texture() { Id = 4, TextureName = "Elephant", TextureDesc = "You are just cruel at this point :D", ImagePath = "Image/something", TexturePrice = 120.22m },
                new Texture() { Id = 5, TextureName = "Metalic", TextureDesc = "Smooth life", ImagePath = "Image/something", TexturePrice = 50.22m },
                new Texture() { Id = 6, TextureName = "Gold", TextureDesc = "If you are into that Pimpin' lifestyle", ImagePath = "Image/something", TexturePrice = 250.22m },
                new Texture() { Id = 7, TextureName = "Silver", TextureDesc = "The name is Bond, James Bond...", ImagePath = "Image/something", TexturePrice = 200.22m });

            modelBuilder.Entity<TextMap>().HasData(
                new TextMap() { Id = 1, ImagePath = "Image/something" }
                );

            modelBuilder.Entity<StandardShader>().HasData(
                new StandardShader() { Id = 1, Metalness = 12.2m, NormalMapIntensity = 3.0m, NormalMapPath = "Image/something", Roughness = 5m }
                );

            modelBuilder.Entity<Watch>().HasData(
                new Watch() { Id = 1, Name = "Apollo", Description = "This is a basic model you can configure it to your liking", WatchImagePath = "Apollo.png", ModelPath = "Models/somethibg", Price = 100.50m },
                new Watch() { Id = 2, Name = "Juno", Description = "Exciting Views, Fresh look, and has a deeper meaning by visualizing the flow of time.", WatchImagePath = "Juno.png", ModelPath = "Models/somethibg", Price = 100.50m },
                new Watch() { Id = 3, Name = "Mercury", Description = "A bald statemnt. That is how I would describe this watch.", WatchImagePath = "Mercury.png", ModelPath = "Models/somethibg", Price = 100.50m });

            modelBuilder.Entity<WatchPart>().HasData(
                new WatchPart() { Id = 1, Name = "Sleeves", TextureMapId = 1, ShaderId = 1, TextMapId = 1 },
                new WatchPart() { Id = 2, Name = "Sleeves", TextureMapId = 2, ShaderId = 1, TextMapId = 1 },
                new WatchPart() { Id = 3, Name = "Sleeves", TextureMapId = 3, ShaderId = 1, TextMapId = 1 },
                new WatchPart() { Id = 4, Name = "Pointers", TextureMapId = 5, ShaderId = 1, TextMapId = 1 },
                new WatchPart() { Id = 5, Name = "Pointers", TextureMapId = 6, ShaderId = 1, TextMapId = 1 },
                new WatchPart() { Id = 6, Name = "BackSide", TextureMapId = 5, ShaderId = 1, TextMapId = 1 },
                new WatchPart() { Id = 7, Name = "BackSide", TextureMapId = 6, ShaderId = 1, TextMapId = 1 },
                new WatchPart() { Id = 8, Name = "TheRoundThing", TextureMapId = 7, ShaderId = 1, TextMapId = 1 },
                new WatchPart() { Id = 9, Name = "Hooks", TextureMapId = 5, ShaderId = 1, TextMapId = 1 });

            modelBuilder.Entity<WatchComponents>().HasData(
                new WatchComponents { WatchId = 1, WatchPartId = 1 },
                new WatchComponents { WatchId = 1, WatchPartId = 5 },
                new WatchComponents { WatchId = 1, WatchPartId = 6 },
                new WatchComponents { WatchId = 1, WatchPartId = 8 },
                new WatchComponents { WatchId = 1, WatchPartId = 9 },
                new WatchComponents { WatchId = 2, WatchPartId = 2 },
                new WatchComponents { WatchId = 2, WatchPartId = 4 },
                new WatchComponents { WatchId = 2, WatchPartId = 7 },
                new WatchComponents { WatchId = 2, WatchPartId = 8 },
                new WatchComponents { WatchId = 2, WatchPartId = 9 },
                new WatchComponents { WatchId = 3, WatchPartId = 3 },
                new WatchComponents { WatchId = 3, WatchPartId = 4 },
                new WatchComponents { WatchId = 3, WatchPartId = 6 },
                new WatchComponents { WatchId = 3, WatchPartId = 8 },
                new WatchComponents { WatchId = 3, WatchPartId = 9 }
                );
        }
    }
}
