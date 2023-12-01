using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBE.Web.API.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [Required]
        public int CATID { get; set; }
        public string CATNAME { get; set; } = null!;

        public  ICollection<SanPham>? SanPham { get; set; }
    }
}
