using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace OOOSportProduct.Classes
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context1")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.categoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Manufacturer>()
                .Property(e => e.manufacturerName)
                .IsUnicode(false);

            modelBuilder.Entity<Manufacturer>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Manufacturer)
                .HasForeignKey(e => e.productManufacturerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.orderClientFio)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderProducts)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderProduct>()
                .Property(e => e.productArticleNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductArticleNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductCost)
                .HasPrecision(19, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductPhoto)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderProducts)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Provider>()
                .Property(e => e.providerName)
                .IsUnicode(false);

            modelBuilder.Entity<Provider>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Provider)
                .HasForeignKey(e => e.productProviderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.roleName)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.userRoleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Unit>()
                .Property(e => e.unitName)
                .IsUnicode(false);

            modelBuilder.Entity<Unit>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Unit)
                .HasForeignKey(e => e.productUnitId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.userSurname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.userPatronymic)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.userLogin)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.userPassword)
                .IsUnicode(false);
        }
    }
}
