using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBE.Web.API.Models
{
    public class CTHDModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CTID { get; set; }
        [Required]
        public int MASP { get; set; }
        [Required]
        public int SL { get; set; }
    }
}
