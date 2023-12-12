using Microsoft.AspNetCore.Mvc;
using ShopBE.Web.API.Models;
using ShopBE.Web.API.Repositories;

namespace ShopBE.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CTHDController : ControllerBase
    {
        private readonly ICTHDRepository _CTHDRepo;

        public CTHDController(ICTHDRepository repo)
        {
            _CTHDRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCTHDs()
        {
            try
            {
                return Ok(await _CTHDRepo.GetAllCTHDsAsyns());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{soHD}")]
        public async Task<IActionResult> GetCTHDbySOHD(int soHD)
        {
            var CTHD = await _CTHDRepo.GetCTHDAsyns(soHD);
            return CTHD == null ? NotFound() : Ok(CTHD);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewSanPham(CTHDModel model)
        {
            try
            {
                var newCTHDsoHD = await _CTHDRepo.AddCTHDAsyns(model);
                var CTHD = await _CTHDRepo.GetCTHDAsyns(newCTHDsoHD);
                return CTHD == null ? NotFound() : Ok(CTHD);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{soHD}")]
        public async Task<IActionResult> UpdateCTHD(int soHD, CTHDModel model)
        {
            if (soHD != model.CTID)
            {
                return NotFound();
            }
            await _CTHDRepo.UpdateCTHDAsyns(soHD, model);
            return Ok();
        }
        [HttpDelete("{soHD}")]

        public async Task<IActionResult> DeleteCTHD(int soHD)
        {
            await _CTHDRepo.DeleteCTHDAsyns(soHD);
            return Ok();
        }
    }
}
