using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Serverbgx.Models
{
    public partial class csdl_baigiuxeContext : DbContext
    {
        public csdl_baigiuxeContext()
        {
        }

        public csdl_baigiuxeContext(DbContextOptions<csdl_baigiuxeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitietravao> Chitietravaos { get; set; } = null!;
        public virtual DbSet<Hinhravao> Hinhravaos { get; set; } = null!;
        public virtual DbSet<Hoadon> Hoadons { get; set; } = null!;
        public virtual DbSet<Khachhang> Khachhangs { get; set; } = null!;
        public virtual DbSet<Loaive> Loaives { get; set; } = null!;
        public virtual DbSet<Nguoidung> Nguoidungs { get; set; } = null!;
        public virtual DbSet<Vaitro> Vaitros { get; set; } = null!;
        public virtual DbSet<Ve> Ves { get; set; } = null!;
        public virtual DbSet<Xe> Xes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=csdl_baigiuxe;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitietravao>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK__Chitietr__3213C8B7708CCA0F");

                entity.ToTable("Chitietravao");

                entity.Property(e => e.Ma).HasColumnName("ma");

                entity.Property(e => e.BiensoXe)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("bienso_xe");

                entity.Property(e => e.MaHoadon).HasColumnName("ma_hoadon");

                entity.Property(e => e.Ngayra)
                    .HasColumnType("datetime")
                    .HasColumnName("ngayra");

                entity.Property(e => e.Ngayvao)
                    .HasColumnType("datetime")
                    .HasColumnName("ngayvao");

                entity.HasOne(d => d.MaHoadonNavigation)
                    .WithMany(p => p.Chitietravaos)
                    .HasForeignKey(d => d.MaHoadon)
                    .HasConstraintName("FK__Chitietra__ma_ho__38996AB5");
            });

            modelBuilder.Entity<Hinhravao>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK__Hinhrava__3213C8B799E46FC0");

                entity.ToTable("Hinhravao");

                entity.Property(e => e.Ma).HasColumnName("ma");

                entity.Property(e => e.MaChitietravao).HasColumnName("ma_chitietravao");

                entity.Property(e => e.Tenhinh)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("tenhinh")
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.MaChitietravaoNavigation)
                    .WithMany(p => p.Hinhravaos)
                    .HasForeignKey(d => d.MaChitietravao)
                    .HasConstraintName("FK__Hinhravao__ma_ch__3C69FB99");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK__Hoadon__3213C8B7D4FEEBC3");

                entity.ToTable("Hoadon");

                entity.Property(e => e.Ma).HasColumnName("ma");

                entity.Property(e => e.Loai).HasColumnName("loai");

                entity.Property(e => e.Ngaylap)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaylap");

                entity.Property(e => e.Sotien)
                    .HasColumnName("sotien")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK__Khachhan__3213C8B7C316781D");

                entity.ToTable("Khachhang");

                entity.Property(e => e.Ma).HasColumnName("ma");

                entity.Property(e => e.Hoten)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("hoten")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sdt");

                entity.Property(e => e.Tenhinh)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("tenhinh")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Loaive>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK__Loaive__3213C8B7B0F9B274");

                entity.ToTable("Loaive");

                entity.Property(e => e.Ma).HasColumnName("ma");

                entity.Property(e => e.Giave).HasColumnName("giave");

                entity.Property(e => e.Loaixe)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("loaixe");

                entity.Property(e => e.Ngaysua)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaysua");

                entity.Property(e => e.Ngaytao)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaytao");

                entity.Property(e => e.Tenloaive)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("tenloaive");

                entity.Property(e => e.Trangthai)
                    .HasColumnName("trangthai")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Nguoidung>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK__Nguoidun__3213C8B77BC96CE2");

                entity.ToTable("Nguoidung");

                entity.Property(e => e.Ma).HasColumnName("ma");

                entity.Property(e => e.Hoten)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("hoten")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MaVaitro).HasColumnName("ma_vaitro");

                entity.Property(e => e.Matkhau)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("matkhau")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ngaysua)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaysua");

                entity.Property(e => e.Ngaytao)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaytao");

                entity.Property(e => e.Taikhoan)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("taikhoan")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Trangthai)
                    .HasColumnName("trangthai")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaVaitroNavigation)
                    .WithMany(p => p.Nguoidungs)
                    .HasForeignKey(d => d.MaVaitro)
                    .HasConstraintName("FK__Nguoidung__ma_va__2A4B4B5E");
            });

            modelBuilder.Entity<Vaitro>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK__Vaitro__3213C8B7181BE23C");

                entity.ToTable("Vaitro");

                entity.Property(e => e.Ma).HasColumnName("ma");

                entity.Property(e => e.Ten)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ten");
            });

            modelBuilder.Entity<Ve>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK__Ve__3213C8B7AE6C0C4D");

                entity.ToTable("Ve");

                entity.Property(e => e.Ma).HasColumnName("ma");

                entity.Property(e => e.BiensoXe)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("bienso_xe");

                entity.Property(e => e.MaHoadon).HasColumnName("ma_hoadon");

                entity.Property(e => e.MaLoaive).HasColumnName("ma_loaive");

                entity.Property(e => e.Ngaygh)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaygh");

                entity.Property(e => e.Ngayhh)
                    .HasColumnType("datetime")
                    .HasColumnName("ngayhh");

                entity.Property(e => e.Ngaykh)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaykh");

                entity.Property(e => e.Trangthai)
                    .HasColumnName("trangthai")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.BiensoXeNavigation)
                    .WithMany(p => p.Ves)
                    .HasForeignKey(d => d.BiensoXe)
                    .HasConstraintName("FK__Ve__bienso_xe__44FF419A");

                entity.HasOne(d => d.MaHoadonNavigation)
                    .WithMany(p => p.Ves)
                    .HasForeignKey(d => d.MaHoadon)
                    .HasConstraintName("FK__Ve__ma_hoadon__4316F928");

                entity.HasOne(d => d.MaLoaiveNavigation)
                    .WithMany(p => p.Ves)
                    .HasForeignKey(d => d.MaLoaive)
                    .HasConstraintName("FK__Ve__ma_loaive__440B1D61");
            });

            modelBuilder.Entity<Xe>(entity =>
            {
                entity.HasKey(e => e.Bienso)
                    .HasName("PK__Xe__8562C4EF097E9281");

                entity.ToTable("Xe");

                entity.Property(e => e.Bienso)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("bienso")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MaKhachhang).HasColumnName("ma_Khachhang");

                entity.Property(e => e.Tenhinh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tenhinh")
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.MaKhachhangNavigation)
                    .WithMany(p => p.Xes)
                    .HasForeignKey(d => d.MaKhachhang)
                    .HasConstraintName("FK__Xe__ma_Khachhang__32E0915F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
