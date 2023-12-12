using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBE.Web.API.Models
{
    public class CategoryModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CATID { get; set; }
        public string CATNAME { get; set; } = null!;
    }
}
