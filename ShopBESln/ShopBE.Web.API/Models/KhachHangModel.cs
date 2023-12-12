using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopBE.Web.API.Models
{
    public class KhachHangModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAKH { get; set; }
        [Required]
        [MaxLength(225)]
        public string HOTEN { get; set; } = null!;
        [Required]
        public string DCHI { get; set; } = string.Empty;
        [Required]
        public string SODT { get; set; } = string.Empty;

        [Required]
        public DateTime NGSINH { get; set; }
        [Required]
        public DateTime NGDK { get; set; }
        [Required]
        [Column(TypeName = "decimal(8, 3)")]
        public decimal DOANHSO { get; set; }
    }
}
