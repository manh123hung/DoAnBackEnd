using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBE.Web.API.Models
{
    public class HoaDonModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
    }
}
