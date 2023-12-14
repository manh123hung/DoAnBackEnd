using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopBE.Web.API.Models;

namespace ShopBE.Web.API.Data
{
    public class ShopDbContext : IdentityDbContext<ShopUser>
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options) { }
        #region Dbset
        public DbSet<SanPham> SanPhams { get; set; }
       
        #endregion
        #region Dbset
        public DbSet<NhanVien> NhanViens { get; set; }
        #endregion
        #region Dbset
        public DbSet<KhachHang> KhachHangs { get; set; }
        #endregion
        #region Dbset
        public DbSet<HoaDon> HoaDons { get; set; }
        #endregion
        #region Dbset
        public DbSet<CTHD> CTHDs { get; set; }
        #endregion
        #region Dbset
        public DbSet<Category> Categories { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SanPham>()
           .Property(p => p.MaSP)
           .ValueGeneratedNever(); // Tắt tính năng identity cho cột MaSP
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<NhanVien>()
           .Property(n => n.MANV)
           .ValueGeneratedNever(); // Tắt tính năng identity cho cột MaSP
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<KhachHang>()
           .Property(k => k.MAKH)
           .ValueGeneratedNever(); // Tắt tính năng identity cho cột MaSP
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HoaDon>()
           .Property(h => h.SOHD)
           .ValueGeneratedNever(); // Tắt tính năng identity cho cột MaSP
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CTHD>()
           .Property(ct => ct.CTID)
           .ValueGeneratedNever(); // Tắt tính năng identity cho cột MaSP
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>()
           .Property(c => c.CATID)
           .ValueGeneratedNever(); // Tắt tính năng identity cho cột MaSP
            base.OnModelCreating(modelBuilder);

            // Thiết lập mối quan hệ giữa HoaDon và KhachHang
            modelBuilder.Entity<HoaDon>()
                .HasOne(hd => hd.KhachHang)
                .WithMany(kh => kh.HoaDon)
                .HasForeignKey(hd => hd.MAKH)
                .OnDelete(DeleteBehavior.Restrict);

            // Thiết lập mối quan hệ giữa HoaDon và NhanVien
            modelBuilder.Entity<HoaDon>()
                .HasOne(hd => hd.NhanVien)
                .WithMany(nv => nv.HoaDon)
                .HasForeignKey(hd => hd.MANV)
                .OnDelete(DeleteBehavior.Restrict);

            // Thiết lập mối quan hệ giữa CTHD và HoaDon
            modelBuilder.Entity<CTHD>()
                .HasOne(cthd => cthd.HoaDon)
                .WithMany(hd => hd.CTHD)
                .HasForeignKey(cthd => cthd.CTID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CTHD>()
                 .HasOne(cthd => cthd.SanPham)
                 .WithMany(sp => sp.CTHD)
                 .HasForeignKey(cthd => cthd.MASP)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
