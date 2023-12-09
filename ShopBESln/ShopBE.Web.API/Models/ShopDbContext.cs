using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ShopBE.Web.API.Models
{
    public class ShopDbContext : IdentityDbContext<ShopUser>
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options) { }
        #region Dbset
        public DbSet<SanPham> SanPhams { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                .HasForeignKey(cthd => cthd.SOHD)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CTHD>()
                 .HasOne(cthd => cthd.SanPham)
                 .WithMany(sp => sp.CTHD)
                 .HasForeignKey(cthd => cthd.MASP)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
