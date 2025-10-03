using Data.Entities.Models;
using Data.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class UaiMenuDbContext : DbContext
    {
        public UaiMenuDbContext(DbContextOptions<UaiMenuDbContext> opt) : base(opt) { }

        public DbSet<Restaurant> Restaurants => Set<Restaurant>();
        public DbSet<Admin> Admins => Set<Admin>();
        public DbSet<Cliente> Clients => Set<Cliente>();
        public DbSet<Subscription> Subscriptions => Set<Subscription>();
        public DbSet<Menu> Menus => Set<Menu>();
        public DbSet<MenuItem> MenuItems => Set<MenuItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // restaurant
                    
            modelBuilder.Entity<Restaurant>(b =>
            {
                b.ToTable("restaurant");
                b.HasKey(x => x.Id);
                b.Property(x => x.Nome)
                    .HasMaxLength(120)
                    .IsRequired();
                b.HasIndex(b => b.Nome).IsUnique();
                b.Property(b => b.Descricao)
                    .HasMaxLength(600);
            });

            // admin
            modelBuilder.Entity<Admin>(b =>
            {
                b.ToTable("admin");
                b.HasKey(x => x.Id);
                b.Property(x => x.Email)
                    .HasMaxLength(120)
                    .IsRequired();
                b.HasIndex(x => x.Email).IsUnique();
                b.Property(x => x.SenhaHash).HasMaxLength(60).IsRequired();

                b.HasOne(x => x.Restaurant)
                 .WithMany(r => r.Admins)
                 .HasForeignKey(x => x.RestaurantId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // client
            modelBuilder.Entity<Cliente>(b =>
            {
                b.ToTable("client");
                b.HasKey(x => x.Id);
                b.Property(x => x.Phone).HasMaxLength(20).IsRequired();
                b.Property(x => x.Email).HasMaxLength(120).IsRequired();
                b.Property(x => x.SenhaHash).HasMaxLength(60).IsRequired();
                b.Property(x => x.Nome).HasMaxLength(120);
                b.Property(x => x.OptIn).HasColumnName("opt_in"); 
                b.HasIndex(x => x.Phone).IsUnique();
                b.HasIndex(x => x.Email).IsUnique();
            });

            // subscription
            modelBuilder.Entity<Subscription>(b =>
            {
                b.ToTable("subscription");
                b.HasKey(x => x.Id);

                b.Property(x => x.HoraEnvioLocal)
                 .HasColumnName("hora_envio_local")
                 .HasColumnType("time")
                 .HasDefaultValueSql("'10:00:00'");


                b.Property(x => x.Days)
                    .HasColumnName("days")
                    .HasConversion(Converters.WeekdayArrayToSet)
                    .HasColumnType("set('dom','seg','ter','qua','qui','sex','sab')");
               

                b.HasIndex(x => new { x.ClientId, x.RestaurantId })
                 .IsUnique()
                 .HasDatabaseName("uq_subscription");

                b.HasOne(x => x.Client)
                 .WithMany(c => c.Subscriptions)
                 .HasForeignKey(x => x.ClientId)
                 .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(x => x.Restaurant)
                 .WithMany(r => r.Subscriptions)
                 .HasForeignKey(x => x.RestaurantId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // menu
            modelBuilder.Entity<Menu>(b =>
            {
                b.ToTable("menu");
                b.HasKey(x => x.Id);
                

                b.Property(x => x.MenuDate)
                    .HasColumnName("menu_date")
                    .HasMaxLength(3)
                    .HasConversion(Converters.WeekdayToPt)
                     .HasColumnType("enum('dom','seg','ter','qua','qui','sex','sab')")
                    .IsRequired();
                //b.Property(x => x.Notas).HasMaxLength(255);

                b.HasIndex(x => new { x.RestaurantId, x.MenuDate })
                 .IsUnique()
                 .HasDatabaseName("uq_menu_rest_dow");

                b.HasOne(x => x.Restaurant)
                 .WithMany(r => r.Menus)
                 .HasForeignKey(x => x.RestaurantId)
                 .OnDelete(DeleteBehavior.Cascade);

                b.HasMany(m => m.Itens)
                 .WithMany(i => i.Menus)
                 .UsingEntity(j => j.ToTable("menu_menu_item"));
            });

            // menu_item
            modelBuilder.Entity<MenuItem>(b =>
            {
                b.ToTable("menu_item");
                b.HasKey(x => x.Id);

                
                b.Property(x => x.Nome).HasMaxLength(100).IsRequired();
                b.Property(x => x.Posicao).HasDefaultValue(1);
                b.Property(x => x.Tipo)
                    .HasMaxLength(15)
                    .HasConversion(Converters.ItemTipoToLower)
                    .HasColumnType("enum('carne','acompanhamento','salada')")
                    .IsRequired();
                b.HasOne(mi => mi.Restaurant)
                .WithMany(r => r.MenuItems)                
                .HasForeignKey(mi => mi.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            // imagem

            modelBuilder.Entity<ImageFile>(b =>
            {
                b.ToTable("imagem_file");
                b.HasKey(x => x.Id);

                b.Property(x => x.FileName).HasMaxLength(100).IsRequired();
                b.Property(x => x.ContentType).HasMaxLength(100).IsRequired();
                b.Property(x => x.RelativePath).HasMaxLength(255).IsRequired();
                b.Property(x => x.AltText).HasMaxLength(180);

                b.HasIndex(x => x.RelativePath).IsUnique();

                b.HasOne(x => x.Restaurant)
                 .WithMany(r => r.Images)
                 .HasForeignKey(x => x.RestaurantId)
                 .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(x => x.Menu)
                 .WithMany(m => m.Images)
                 .HasForeignKey(x => x.MenuId)
                 .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(x => x.MenuItem)
                 .WithMany(mi => mi.Images)
                 .HasForeignKey(x => x.MenuItemId)
                 .OnDelete(DeleteBehavior.Cascade);

            });
        }
    }
}
