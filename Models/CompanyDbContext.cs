using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Company_CFM.Models;

public partial class CompanyDbContext : DbContext
{
    public CompanyDbContext()
    {
    }

    public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customers> Customers { get; set; }

    public virtual DbSet<Departments> Departments { get; set; }

    public virtual DbSet<Employees> Employees { get; set; }

    public virtual DbSet<Orders> Orders { get; set; }

    public virtual DbSet<Products> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Company;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customers>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Customer__3214EC2712DEAA22");

            entity.ToTable(tb => tb.HasTrigger("trg_GenerateCustomerID"));

            entity.Property(e => e.ID)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Departments>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Departme__3214EC27AFDB88FB");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employees>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Employee__3214EC2783A4F28E");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Department_Id)
                .HasConstraintName("FK__Employees__Depar__2B3F6F97");
        });

        modelBuilder.Entity<Orders>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Orders__3214EC27FC6990AD");

            entity.ToTable(tb => tb.HasTrigger("trg_GenerateOrderID"));

            entity.Property(e => e.ID)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Customer_Id)
                .HasMaxLength(6)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Customer_Id)
                .HasConstraintName("FK__Orders__Customer__35BCFE0A");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Product_Id)
                .HasConstraintName("FK__Orders__Product___36B12243");
        });

        modelBuilder.Entity<Products>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Products__3214EC276F05DA75");

            entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });
        modelBuilder.HasSequence("CustomerSeq");
        modelBuilder.HasSequence("OrderSeq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
