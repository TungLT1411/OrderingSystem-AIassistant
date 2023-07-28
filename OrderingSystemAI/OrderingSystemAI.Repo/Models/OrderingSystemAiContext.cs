using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OrderingSystemAI.Repo.Models;

public partial class OrderingSystemAiContext : DbContext
{
    public OrderingSystemAiContext()
    {
    }

    public OrderingSystemAiContext(DbContextOptions<OrderingSystemAiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<BillDetail> BillDetails { get; set; }

    public virtual DbSet<SubOrder> SubOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=OrderingSystemAI;User ID=sa;Password=12345;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__bill__3213E83F801C9711");

            entity.ToTable("bill");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("date")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateTime)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("create_time");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("total_price");
        });

        modelBuilder.Entity<BillDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__bill_det__3213E83F94B59BC1");

            entity.ToTable("bill_detail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BillId).HasColumnName("bill_id");
            entity.Property(e => e.FoodName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("food_name");
            entity.Property(e => e.FoodPrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("food_price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Bill).WithMany(p => p.BillDetails)
                .HasForeignKey(d => d.BillId)
                .HasConstraintName("FK__bill_deta__quant__3D5E1FD2");
        });

        modelBuilder.Entity<SubOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sub_orde__3213E83F1E5938B7");

            entity.ToTable("sub_order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FoodName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("food_name");
            entity.Property(e => e.FoodPrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("food_price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
