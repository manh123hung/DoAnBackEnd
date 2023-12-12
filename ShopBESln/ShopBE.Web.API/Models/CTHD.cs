using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBE.Web.API.Data
{
    [Table("CTHD")]
    public class CTHD
    {
        [Key]
        [Required]
        public int CTID { get; set; }
        [Required]
        public int MASP { get; set; }
        [Required]
        public int SL { get; set; }

        public virtual HoaDon? HoaDon { get; set; }
        public virtual SanPham? SanPham { get; set; }


    }
}
