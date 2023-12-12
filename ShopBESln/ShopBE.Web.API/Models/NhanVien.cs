using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBE.Web.API.Data
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        [Required]
        
        public int MANV { get; set; }
        [Required]
        [MaxLength(225)]
        public string HOTEN { get; set; } = null!;
        [Required]
        public string SODT { get; set; } = string.Empty;
        [Required]
        public DateTime NGVL { get; set; }
        [Required]
        public string VITRI { get; set; } = string.Empty;

        public ICollection<HoaDon>? HoaDon { get; set; }

    }
}
