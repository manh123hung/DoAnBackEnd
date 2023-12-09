using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBE.Web.API.Data
{
    [Table("HoaDon")]
    public class HoaDon
    {
        [Key]
        [Required]
        public int SOHD { get; set; }
        [Required]
        public DateTime NGHD { get; set; }
        [Required]
        public int MAKH { get; set; }
        [Required]
        public int MANV { get; set; }
        [Required]
        [Column(TypeName = "decimal(8, 3)")]
        public decimal TRIGIA { get; set; }

        public virtual KhachHang? KhachHang { get; set; }
        public virtual NhanVien? NhanVien { get; set; }
        public ICollection<CTHD>? CTHD { get; set; }

    }
}
