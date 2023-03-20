using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Project_PRN211_Nhom5.Models
{
    public partial class Project_PRNContext : DbContext
    {
        public Project_PRNContext()
        {
        }

        public Project_PRNContext(DbContextOptions<Project_PRNContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =DESKTOP-02634KD\\SQLEXPRESS; database =Project_PRN;uid=sa;pwd=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.OdId)
                    .HasName("PK__Hoa_Don__FB4822F6F84995EA");

                entity.ToTable("Hoa_Don");

                entity.Property(e => e.OdId).HasColumnName("od_ID");

                entity.Property(e => e.OdDiaChi)
                    .IsRequired()
                    .HasColumnName("od_Dia_Chi");

                entity.Property(e => e.OdEmail)
                    .HasMaxLength(100)
                    .HasColumnName("od_Email");

                entity.Property(e => e.OdNgayMua)
                    .HasColumnType("date")
                    .HasColumnName("od_Ngay_Mua");

                entity.Property(e => e.OdSoDienThoai)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("od_So_Dien_Thoai");

                entity.Property(e => e.OdSoLuong).HasColumnName("od_So_Luong");

                entity.Property(e => e.OdTenKhachHang)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("od_Ten_Khach_Hang");

                entity.Property(e => e.OdTongTien)
                    .HasColumnType("money")
                    .HasColumnName("od_Tong_Tien");

                entity.Property(e => e.SpId).HasColumnName("sp_ID");

                entity.HasOne(d => d.Sp)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.SpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Hoa_Don__sp_ID__4BAC3F29");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.SpId)
                    .HasName("PK__San_Pham__4FF075560902E95D");

                entity.ToTable("San_Pham");

                entity.Property(e => e.SpId).HasColumnName("sp_ID");

                entity.Property(e => e.SpGiaBab)
                    .HasColumnType("money")
                    .HasColumnName("sp_Gia_Bab");

                entity.Property(e => e.SpGiaGoc)
                    .HasColumnType("money")
                    .HasColumnName("sp_Gia_Goc");

                entity.Property(e => e.SpNgayDat)
                    .HasColumnType("date")
                    .HasColumnName("sp_Ngay_Dat");

                entity.Property(e => e.SpSoLuong).HasColumnName("sp_So_Luong");

                entity.Property(e => e.SpTen)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("sp_Ten");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
