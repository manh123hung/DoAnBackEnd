using Microsoft.AspNetCore.Identity;

namespace ShopBE.Web.API.Models
{
    public class ShopUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
