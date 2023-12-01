using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBE.Web.API.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        [Required]
        public int MAKH { get; set; }
        [Required]
        [MaxLength(225)]
        public string HOTEN { get; set; } = null!;
        [Required]
        public string DCHI { get; set; } = string.Empty;
        [Required]
        public string SODT { get; set; }=string.Empty;
        
        [Required]
        public DateTime NGSINH { get; set; }
        [Required]
        public DateTime NGDK { get; set; }
        [Required]
        [Column(TypeName = "decimal(8, 3)")]
        public decimal DOANHSO { get; set; }

        public ICollection<HoaDon>? HoaDon { get; set; }
    }
}
