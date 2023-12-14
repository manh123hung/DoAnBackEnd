using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBE.Web.API.Data
{
    [Table("SanPham")]
    
    public class SanPham
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSP { get; set; }

        [Required]
        [MaxLength(225)]
        public string TenSP { get; set; } = null!;

        [Required]
        public string DonViTinh { get; set; } = string.Empty;

        
        public string Image { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue)]
        public double Gia { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public ICollection<Category>? Category { get; set; }
        public ICollection<CTHD>? CTHD { get; set; }
    }
}
