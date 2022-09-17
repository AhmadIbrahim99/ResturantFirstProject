using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ResturantFirstProject.Models
{
    public partial class ResturantDBContext : DbContext
    {
        public bool IgnoreFilter { get; set; }
        public ResturantDBContext()
        {
        }

        public ResturantDBContext(DbContextOptions<ResturantDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ReportResturant> ReportResturants { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<RestaurantMenu> RestaurantMenus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\;Database=ResturantDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("date");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
                entity.Property(e => e.TotalPrice).HasColumnName("TotalPrice");
                entity.Property(e => e.Quantity).HasColumnName("Quantity");
                entity.Property(e => e.OrderName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("date");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__IdCustom__33D4B598");

                entity.HasOne(d => d.IdResturantMenuNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdResturantMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__IdRestur__32E0915F");
            });

            modelBuilder.Entity<ReportResturant>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ReportResturant");

                entity.Property(e => e.PricieInNis).HasColumnName("PricieInNIS");

                entity.Property(e => e.Rank).HasColumnName("Rank_");

                entity.Property(e => e.RestuarntName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ResturantId).HasColumnName("resturantId");

                entity.Property(e => e.TheMostPurchasedCustomer)
                    .IsRequired()
                    .HasMaxLength(511)
                    .IsUnicode(false);

                entity.Property(e => e.TotalOrders).HasColumnName("total_orders");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("date");
            });

            modelBuilder.Entity<RestaurantMenu>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MealName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("mealName");

                entity.Property(e => e.PricieInNis).HasColumnName("PricieInNIS");

                entity.Property(e => e.UpdatedAt).HasColumnType("date");

                entity.HasOne(d => d.IdRestaurantNavigation)
                    .WithMany(p => p.RestaurantMenus)
                    .HasForeignKey(d => d.IdRestaurant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Restauran__IdRes__2A4B4B5E");
            });
            modelBuilder.Entity<Order>().HasQueryFilter(x=> !x.Archived || IgnoreFilter);
            modelBuilder.Entity<Restaurant>().HasQueryFilter(x=> !x.Archived || IgnoreFilter);
            modelBuilder.Entity<RestaurantMenu>().HasQueryFilter(x=> !x.Archived || IgnoreFilter);
            modelBuilder.Entity<Customer>().HasQueryFilter(x=> !x.Archived || IgnoreFilter);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
