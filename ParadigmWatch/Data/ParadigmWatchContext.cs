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
        public DbSet<WatchPart> WatchParts { get; set; }
        public DbSet<WatchComponents> RelationTableWatch { get; set; }
        public DbSet<StandardShader> StandardShaders { get; set; }
        public DbSet<TextMap> TextMaps { get; set; }
        public DbSet<Texture> Textures { get; set; }
        public DbSet<Backgrounds> Backgrounds { get; set; }
        public DbSet<Discounts> Discounts { get; set; }
        public DbSet<WatchPartType> WatchPartyTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Discounts Table
            modelBuilder.Entity<Discounts>().ToTable("Discounts").HasKey(p => p.Id);

            // Backgrounds Table
            modelBuilder.Entity<Backgrounds>().ToTable("Backgrounds").HasKey(p => p.Id);

            // Invoice Table
            modelBuilder.Entity<Invoice>().ToTable("Invoice").HasKey(b => b.InvoiceId);
            modelBuilder.Entity<Invoice>(item =>
            {
                item.Property(b => b.TotalPrice).HasColumnType("float");
            });

            // OrderItem Table
            modelBuilder.Entity<OrderItem>().ToTable("OrderItem").HasKey(b => b.Id);
            modelBuilder.Entity<OrderItem>()
                .Property(b => b.TotalPrice)
                .HasColumnType("float");

            // Watch Table
            modelBuilder.Entity<Watch>().HasKey(b => b.Id);
            modelBuilder.Entity<Watch>()
                .ToTable("Watch")
                .Property(b => b.Price)
                .HasColumnType("float");

            // WatchPart Table
            modelBuilder.Entity<WatchPart>(item =>
            {
                item.Property(b => b.Id).ValueGeneratedOnAdd();
                item.Property(b => b.Name).HasMaxLength(50).IsRequired();
                item.Property(b => b.TextureMapId).IsRequired();
                item.Property(b => b.ShaderId).IsRequired();
                item.Property(b => b.TypeId).IsRequired();
            });
            modelBuilder.Entity<WatchPart>().ToTable("WatchPart").HasKey(b => b.Id);

            // WatchPartType Table
            modelBuilder.Entity<WatchPartType>().ToTable("WatchPartType").HasKey(b => b.Id);

            // Shader Table
            modelBuilder.Entity<StandardShader>().ToTable("StandardShader").HasKey(b => b.Id);

            modelBuilder.Entity<StandardShader>(item =>
            {
                item.Property(b => b.Metalness).HasColumnType("float");
                item.Property(b => b.Roughness).HasColumnType("float");
                item.Property(b => b.NormalMapIntensity).HasColumnType("float");
            });

            // Texture Table
            modelBuilder.Entity<Texture>().ToTable("Texture").HasKey(b => b.Id);
            modelBuilder.Entity<Texture>(item =>
           {
               item.Property(b => b.ImagePath).IsRequired();
               item.Property(b => b.TextureName).HasMaxLength(50).IsRequired();
               item.Property(b => b.TextureDesc).HasMaxLength(150).IsRequired();
               item.Property(b => b.TexturePrice).HasColumnType("float").IsRequired();
           });
            modelBuilder.Entity<TextMap>().ToTable("TextMap");

            // Setting up many-to-many
            modelBuilder.Entity<WatchComponents>()
                .ToTable("RelationTableWatch")
                .HasKey(key => new { key.WatchId, key.WatchPartId });
            modelBuilder.Entity<WatchComponents>()
            .HasOne(pt => pt.Watch)
            .WithMany(p => p.WatchComponents)
            .HasForeignKey(pt => pt.WatchId);

            modelBuilder.Entity<WatchComponents>()
                .HasOne(pt => pt.WatchPart)
                .WithMany(t => t.WatchComponents)
                .HasForeignKey(pt => pt.WatchPartId);

            modelBuilder.Entity<Texture>().HasData(
                new Texture() { Id = 1, TextureName = "Leather", TextureDesc = "This Leather makes you look rich&stuff", ImagePath = "models/strap.png", TexturePrice = 50.22m },
                new Texture() { Id = 2, TextureName = "Chrome", TextureDesc = "Cold but Cool", ImagePath = "models/chrome.png", TexturePrice = 100.22m },
                new Texture() { Id = 3, TextureName = "Apollo Dial", TextureDesc = "Wanna be the most badass person? try this then!", ImagePath = "models/watchFrontTexture.png", TexturePrice = 33.4m },
                new Texture() { Id = 4, TextureName = "Solid Handle", TextureDesc = "Simple but elegant", ImagePath = "", TexturePrice = 80.22m },
                new Texture() { Id = 5, TextureName = "Silver", TextureDesc = "James Bond would have the same", ImagePath = "models/Silver.png", TexturePrice = 250.22m },
                new Texture() { Id = 6, TextureName = "Gold", TextureDesc = "If you are into that Pimpin' lifestyle", ImagePath = "models/gold.png", TexturePrice = 300.22m },
                new Texture() { Id = 7, TextureName = "Bronze", TextureDesc = "This still makes you look no.1", ImagePath = "models/Bronze.png", TexturePrice = 200.22m },
                new Texture() { Id = 8, TextureName = "Blue Leather", TextureDesc = "Colorful look for a colorful personality", ImagePath = "models/BlueStrap.png", TexturePrice = 175.22m },
                new Texture() { Id = 9, TextureName = "Red Leather", TextureDesc = "Bursting with energy", ImagePath = "models/RedsStrap.png", TexturePrice = 175.22m },
                new Texture() { Id = 10, TextureName = "Brown Leather", TextureDesc = "Smooth criminal", ImagePath = "models/Brownstrap.png", TexturePrice = 150.22m },
                new Texture() { Id = 11, TextureName = "Mercury Dial", TextureDesc = "This will make some heads turn!", ImagePath = "models/MercuryPattern.png", TexturePrice = 50.22m },
                new Texture() { Id = 12, TextureName = "Juno Dial", TextureDesc = "Represents the flow of time", ImagePath = "models/JunoPattern.png", TexturePrice = 50.22m },
                new Texture() { Id = 13, TextureName = "Glass", TextureDesc = "Gorilla Glass XI", ImagePath = "", TexturePrice = 0m }

                );

            modelBuilder.Entity<TextMap>().HasData(
                new TextMap() { Id = 1, ImagePath = "Image/something" }
                );

            modelBuilder.Entity<StandardShader>().HasData(
                new StandardShader() { Id = 1, Metalness = 0m, NormalMapIntensity = 0.1m, NormalMapPath = "models/strap.png", Roughness = 0.9m, EnvMapIntensity = 1},
                new StandardShader() { Id = 2, Metalness = 1m, NormalMapIntensity = 0.05m, NormalMapPath = "models/chrome.png", Roughness = 0.15m, EnvMapIntensity = 2 },
                new StandardShader() { Id = 3, Metalness = 0m, NormalMapIntensity = 0m, NormalMapPath = "", Roughness = 0.5m, EnvMapIntensity = 1 },
                new StandardShader() { Id = 4, Metalness = 0m, NormalMapIntensity = 0m, NormalMapPath = "", Roughness = 0m, EnvMapIntensity = 1 },
                new StandardShader() { Id = 5, Metalness = 0m, NormalMapIntensity = 0m, NormalMapPath = "", Roughness = 0m, EnvMapIntensity = 1 },
                new StandardShader() { Id = 6, Metalness = 1m, NormalMapIntensity = 0.05m, NormalMapPath = "models/strap.png", Roughness = 0.15m, EnvMapIntensity = 3 }
                );

            modelBuilder.Entity<Watch>().HasData(
                new Watch() { Id = 1, Name = "Apollo", Description = "This is a basic model you can configure it to your liking", WatchImagePath = "Apollo.png", Price = 100.50m },
                new Watch() { Id = 2, Name = "Juno", Description = "Exciting Views, Fresh look, and has a deeper meaning by visualizing the flow of time.", WatchImagePath = "Juno.png", Price = 100.50m },
                new Watch() { Id = 3, Name = "Mercury", Description = "A bald statemnt. That is how I would describe this watch.", WatchImagePath = "Mercury.png", Price = 100.50m });


            modelBuilder.Entity<WatchPartType>().HasData(
                new WatchPartType() { Id = 1, Name = "Pattern" },
                new WatchPartType() { Id = 2, Name = "BackSide" },
                new WatchPartType() { Id = 3, Name = "Base" },
                new WatchPartType() { Id = 4, Name = "Decoration" },
                new WatchPartType() { Id = 5, Name = "Pointer" },
                new WatchPartType() { Id = 6, Name = "Sleeve" },
                new WatchPartType() { Id = 7, Name = "Glass" },
                new WatchPartType() { Id = 8, Name = "Ring" }
            );

            modelBuilder.Entity<WatchPart>().HasData(
                new WatchPart() { Id = 1, Name = "Apollo Pattern", TextureMapId = 3, ShaderId = 3, TextMapId = 1, TypeId = 1, ModelPath = "models/Parts/Backgrounds/Apollo.gltf" },
                new WatchPart() { Id = 2, Name = "Chrome Back part", TextureMapId = 2, ShaderId = 2, TextMapId = 1, TypeId = 2, ModelPath = "models/Parts/BackSides/DefaultBack.gltf" },
                new WatchPart() { Id = 3, Name = "Chrome Base", TextureMapId = 2, ShaderId = 2, TextMapId = 1, TypeId = 3, ModelPath = "models/Parts/Bases/DefaultBase.gltf" },
                new WatchPart() { Id = 4, Name = "Chrome Decorations", TextureMapId = 2, ShaderId = 2, TextMapId = 1, TypeId = 4, ModelPath = "models/Parts/Decorations/DefaultDecoration.gltf" },
                new WatchPart() { Id = 5, Name = "Silver Pointer", TextureMapId = 4, ShaderId = 4, TextMapId = 1, TypeId = 5, ModelPath = "models/Parts/Pointers/DefaultPointer.gltf" },
                new WatchPart() { Id = 6, Name = "Black Sleeves", TextureMapId = 1, ShaderId = 1, TextMapId = 1, TypeId = 6, ModelPath = "models/Parts/Sleeves/DefaultSleeve.gltf" },
                new WatchPart() { Id = 7, Name = "Crystal Glass", TextureMapId = 13, ShaderId = 5, TextMapId = 1, TypeId = 7, ModelPath = "models/Parts/Glasses/DefaultGlass.gltf" },
                new WatchPart() { Id = 8, Name = "Chrome Ring", TextureMapId = 2, ShaderId = 2, TextMapId = 1, TypeId = 8, ModelPath = "models/Parts/Rings/DefaultRing.gltf" },

                new WatchPart() { Id = 10, Name = "Juno Pattern", TextureMapId = 12, ShaderId = 3, TextMapId = 1, TypeId = 1, ModelPath = "models/Parts/Backgrounds/Apollo.gltf" },
                new WatchPart() { Id = 11, Name = "Mercury Pattern", TextureMapId = 11, ShaderId = 3, TextMapId = 1, TypeId = 1, ModelPath = "models/Parts/Backgrounds/Apollo.gltf" },

                new WatchPart() { Id = 12, Name = "Gold Back part", TextureMapId = 6, ShaderId = 2, TextMapId = 1, TypeId = 2, ModelPath = "models/Parts/BackSides/DefaultBack.gltf" },
                new WatchPart() { Id = 13, Name = "Bronze Back part", TextureMapId = 7, ShaderId = 2, TextMapId = 1, TypeId = 2, ModelPath = "models/Parts/BackSides/DefaultBack.gltf" },
                new WatchPart() { Id = 14, Name = "Silver Back part", TextureMapId = 5, ShaderId = 2, TextMapId = 1, TypeId = 2, ModelPath = "models/Parts/BackSides/DefaultBack.gltf" },

                new WatchPart() { Id = 15, Name = "Silver Base", TextureMapId = 5, ShaderId = 2, TextMapId = 1, TypeId = 3, ModelPath = "models/Parts/Bases/DefaultBase.gltf" },
                new WatchPart() { Id = 16, Name = "Gold Base", TextureMapId = 6, ShaderId = 2, TextMapId = 1, TypeId = 3, ModelPath = "models/Parts/Bases/DefaultBase.gltf" },
                new WatchPart() { Id = 17, Name = "Bronze Base", TextureMapId = 7, ShaderId = 2, TextMapId = 1, TypeId = 3, ModelPath = "models/Parts/Bases/DefaultBase.gltf" },

                new WatchPart() { Id = 18, Name = "Silver Decorations", TextureMapId = 5, ShaderId = 2, TextMapId = 1, TypeId = 4, ModelPath = "models/Parts/Decorations/DefaultDecoration.gltf" },
                new WatchPart() { Id = 19, Name = "Gold Decorations", TextureMapId = 6, ShaderId = 2, TextMapId = 1, TypeId = 4, ModelPath = "models/Parts/Decorations/DefaultDecoration.gltf" },
                new WatchPart() { Id = 20, Name = "Bronze Decorations", TextureMapId = 7, ShaderId = 2, TextMapId = 1, TypeId = 4, ModelPath = "models/Parts/Decorations/DefaultDecoration.gltf" },

                new WatchPart() { Id = 21, Name = "Blue Sleeves", TextureMapId = 8, ShaderId = 1, TextMapId = 1, TypeId = 6, ModelPath = "models/Parts/Sleeves/DefaultSleeve.gltf" },
                new WatchPart() { Id = 22, Name = "Red Sleeves", TextureMapId = 9, ShaderId = 1, TextMapId = 1, TypeId = 6, ModelPath = "models/Parts/Sleeves/DefaultSleeve.gltf" },
                new WatchPart() { Id = 23, Name = "Brown Sleeves", TextureMapId = 10, ShaderId = 1, TextMapId = 1, TypeId = 6, ModelPath = "models/Parts/Sleeves/DefaultSleeve.gltf" },

                new WatchPart() { Id = 24, Name = "Silver Ring", TextureMapId = 5, ShaderId = 2, TextMapId = 1, TypeId = 8, ModelPath = "models/Parts/Rings/DefaultRing.gltf" },
                new WatchPart() { Id = 25, Name = "Gold Ring", TextureMapId = 6, ShaderId = 2, TextMapId = 1, TypeId = 8, ModelPath = "models/Parts/Rings/DefaultRing.gltf" },
                new WatchPart() { Id = 26, Name = "Bronze Ring", TextureMapId = 7, ShaderId = 2, TextMapId = 1, TypeId = 8, ModelPath = "models/Parts/Rings/DefaultRing.gltf" }
                );

            

            modelBuilder.Entity<WatchComponents>().HasData(
                new WatchComponents { WatchId = 1, WatchPartId = 1 },
                new WatchComponents { WatchId = 1, WatchPartId = 2 },
                new WatchComponents { WatchId = 1, WatchPartId = 3 },
                new WatchComponents { WatchId = 1, WatchPartId = 4 },
                new WatchComponents { WatchId = 1, WatchPartId = 5 },
                new WatchComponents { WatchId = 1, WatchPartId = 6 },
                new WatchComponents { WatchId = 1, WatchPartId = 7 },
                new WatchComponents { WatchId = 1, WatchPartId = 8 },

                new WatchComponents { WatchId = 2, WatchPartId = 10 },
                new WatchComponents { WatchId = 2, WatchPartId = 14 },
                new WatchComponents { WatchId = 2, WatchPartId = 15 },
                new WatchComponents { WatchId = 2, WatchPartId = 18 },
                new WatchComponents { WatchId = 2, WatchPartId = 5 },
                new WatchComponents { WatchId = 2, WatchPartId = 23 },
                new WatchComponents { WatchId = 2, WatchPartId = 7 },
                new WatchComponents { WatchId = 2, WatchPartId = 24 },

                new WatchComponents { WatchId = 3, WatchPartId = 11 },
                new WatchComponents { WatchId = 3, WatchPartId = 13 },
                new WatchComponents { WatchId = 3, WatchPartId = 17 },
                new WatchComponents { WatchId = 3, WatchPartId = 20 },
                new WatchComponents { WatchId = 3, WatchPartId = 5 },
                new WatchComponents { WatchId = 3, WatchPartId = 23 },
                new WatchComponents { WatchId = 3, WatchPartId = 7 },
                new WatchComponents { WatchId = 3, WatchPartId = 26 }
                );

            modelBuilder.Entity<Backgrounds>().HasData(
                new Backgrounds() { Id = 1, BackgroundName = "HallwayBG", fileName = "nx.png" },
                new Backgrounds() { Id = 2, BackgroundName = "HallwayBG", fileName = "ny.png" },
                new Backgrounds() { Id = 3, BackgroundName = "HallwayBG", fileName = "nz.png" },
                new Backgrounds() { Id = 4, BackgroundName = "HallwayBG", fileName = "px.png" },
                new Backgrounds() { Id = 5, BackgroundName = "HallwayBG", fileName = "py.png" },
                new Backgrounds() { Id = 6, BackgroundName = "HallwayBG", fileName = "pz.png" },
                new Backgrounds() { Id = 7, BackgroundName = "ShanghaiBG", fileName = "nx.png" },
                new Backgrounds() { Id = 8, BackgroundName = "ShanghaiBG", fileName = "ny.png" },
                new Backgrounds() { Id = 9, BackgroundName = "ShanghaiBG", fileName = "nz.png" },
                new Backgrounds() { Id = 10, BackgroundName = "ShanghaiBG", fileName = "px.png" },
                new Backgrounds() { Id = 11, BackgroundName = "ShanghaiBG", fileName = "py.png" },
                new Backgrounds() { Id = 12, BackgroundName = "ShanghaiBG", fileName = "pz.png" }
                );
        }
    }
}
