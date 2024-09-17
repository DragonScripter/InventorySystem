using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data;

public partial class InventoryContext : DbContext
{
    public InventoryContext()
    {
    }

    public InventoryContext(DbContextOptions<InventoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        //#warning To protect potentially sensitive information in your connection string,
        //you should move it out of source code. You can avoid scaffolding the connection string
        //by using the Name= syntax to read it from configuration - see
        //https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings,
        //see https://go.microsoft.com/fwlink/?LinkId=723263.
        //Scaffold-DbContext "Server=(localdb)\ProjectModels;Database=Inventory;Trusted_Connection=True;"Microsoft.EntityFrameworkCore.SqlServer -Context InventoryContext -UseDatabaseNames
       //  
        //

        if (!optionsBuilder.IsConfigured) 
        {
            optionsBuilder.UseSqlServer("Server=(localdb)//ProjectModels;Database=Inventory;Trusted_Connection=True;");
        }
       }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductID).HasName("PK__Products__B40CC6ED356D00FA");

            entity.HasIndex(e => e.SKU, "UQ__Products__CA1ECF0DAC1A987C").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SKU).HasMaxLength(50);
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.OrderID).HasName("PK__Purchase__C3905BAFAF953C9B");

            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.Supplier).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.SupplierID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseO__Suppl__2F10007B");
        });

        modelBuilder.Entity<PurchaseOrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailID).HasName("PK__Purchase__D3B9D30C81E7766C");

            entity.HasOne(d => d.Order).WithMany(p => p.PurchaseOrderDetails)
                .HasForeignKey(d => d.OrderID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseO__Order__31EC6D26");

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseOrderDetails)
                .HasForeignKey(d => d.ProductID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseO__Produ__32E0915F");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleID).HasName("PK__Sales__1EE3C41F3BC617F1");

            entity.Property(e => e.SaleAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SaleDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ProductID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sales__ProductID__2A4B4B5E");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierID).HasName("PK__Supplier__4BE66694BACF7C92");

            entity.Property(e => e.ContactInfo).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
