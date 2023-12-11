using System.ComponentModel.DataAnnotations;

namespace ShopBE.Web.API.Models
{
    public class CTHDModel
    {
        public int SOHD { get; set; }
        [Required]
        public int MASP { get; set; }
        [Required]
        public int SL { get; set; }
    }
}
