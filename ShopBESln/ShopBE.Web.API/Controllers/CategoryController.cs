using Microsoft.AspNetCore.Mvc;
using ShopBE.Web.API.Models;
using ShopBE.Web.API.Repositories;

namespace ShopBE.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _CategoryRepo;

        public CategoryController(ICategoryRepository repo)
        {
            _CategoryRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategorys()
        {
            try
            {
                return Ok(await _CategoryRepo.GetAllCategorysAsyns());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{catID}")]
        public async Task<IActionResult> GetCategorybycatID(int catID)
        {
            var Category = await _CategoryRepo.GetCategoryAsyns(catID);
            return Category == null ? NotFound() : Ok(Category);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewSanPham(CategoryModel model)
        {
            try
            {
                var newCategorycatID = await _CategoryRepo.AddCategoryAsyns(model);
                var Category = await _CategoryRepo.GetCategoryAsyns(newCategorycatID);
                return Category == null ? NotFound() : Ok(Category);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{catID}")]
        public async Task<IActionResult> UpdateCategory(int catID, CategoryModel model)
        {
            if (catID != model.CATID)
            {
                return NotFound();
            }
            await _CategoryRepo.UpdateCategoryAsyns(catID, model);
            return Ok();
        }
        [HttpDelete("{catID}")]

        public async Task<IActionResult> DeleteCategory(int catID)
        {
            await _CategoryRepo.DeleteCategoryAsyns(catID);
            return Ok();
        }
    }
}

