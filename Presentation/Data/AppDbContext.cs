using System;
using System.Collections.Generic;
using finalproject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace finalproject.Presentation.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DangKy> DangKies { get; set; }

    public virtual DbSet<LopHoc> LopHocs { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=qlsv;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DangKy>(entity =>
        {
            entity.Property(e => e.Ngaydangky).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Trangthai).HasDefaultValue("DangHoc");

            entity.HasOne(d => d.MalopNavigation).WithMany(p => p.DangKies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DK_Lop");

            entity.HasOne(d => d.MasinhvienNavigation).WithMany(p => p.DangKies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DK_SV");
        });

        modelBuilder.Entity<LopHoc>(entity =>
        {
            entity.Property(e => e.Sophong).IsFixedLength();
            entity.Property(e => e.Tenlop).IsFixedLength();
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SinhVien__3213E83F4A256846");

            entity.Property(e => e.Mssv).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
