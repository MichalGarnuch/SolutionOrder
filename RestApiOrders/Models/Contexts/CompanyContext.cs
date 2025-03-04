using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RestApiOrders.Models;

namespace RestApiOrders.Models.Contexts
{
    public partial class CompanyContext : DbContext
    {
        public CompanyContext()
        {
        }

        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.IdCategory).ValueGeneratedNever();
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.IdClient).ValueGeneratedNever();
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.IdItem).ValueGeneratedNever();

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_Category");

                entity.HasOne(d => d.IdUnitOfMeasurementNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.IdUnitOfMeasurement)
                    .HasConstraintName("FK_Item_UnitOfMeasurement");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK__Order__C38F3009C7CFDA46");

                entity.Property(e => e.IdOrder).ValueGeneratedNever();

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("FK_Order_Client");

                entity.HasOne(d => d.IdWorkerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdWorker)
                    .HasConstraintName("FK_Order_Worker");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.IdOrderItem).ValueGeneratedNever();

                entity.HasOne(d => d.IdItemNavigation)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.IdItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItem_Item");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItem_Order");
            });

            modelBuilder.Entity<UnitOfMeasurement>(entity =>
            {
                entity.Property(e => e.IdUnitOfMeasurement).ValueGeneratedNever();
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.Property(e => e.IdWorker).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
