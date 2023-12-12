using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBE.Web.API.Models
{
    public class SanPhamModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Giữ giá trị được cung cấp
        public int MaSP { get; set; }

        [Required]
        [MaxLength(225)]
        public string TenSP { get; set; } = null!;
        [Required]
        public string? DonViTinh { get; set; }
        [Required]
        public string? Image { get; set; }
        [Required]
        public string? Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Gia { get; set; }

        [Required]
        public int CategoryID { get; set; }
    }
}
