using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBE.Web.API.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        [Required]
        public int MaSP { get; set; }

        [Required]
        [MaxLength(225)]
        public string TenSP { get; set; } = null!;

        [Required]
        public string DonViTinh { get; set; } = string.Empty;

        [Required]
        public string Image { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(8, 3)")]
        public decimal Gia { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public  ICollection<Category>? Category { get; set; }
        public ICollection<CTHD>? CTHD { get; set; }
    }
}
