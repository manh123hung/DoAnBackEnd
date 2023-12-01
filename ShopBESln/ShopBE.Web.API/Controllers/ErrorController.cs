using Microsoft.AspNetCore.Mvc;

namespace ShopBE.Web.API.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        [HttpGet] 
        public IActionResult Error() 
        { return Problem(); 
        }
        [Route("/error/test")]
        [HttpGet] 
        public IActionResult Test() { 
            throw new Exception("test"); }
    }
}



