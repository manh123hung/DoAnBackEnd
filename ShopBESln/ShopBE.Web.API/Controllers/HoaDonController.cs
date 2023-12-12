using Microsoft.AspNetCore.Mvc;
using ShopBE.Web.API.Models;
using ShopBE.Web.API.Repositories;

namespace ShopBE.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly IHoaDonRepository _HoaDonRepo;

        public HoaDonController(IHoaDonRepository repo)
        {
            _HoaDonRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHoaDons()
        {
            try
            {
                return Ok(await _HoaDonRepo.GetAllHoaDonsAsyns());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{soHD}")]
        public async Task<IActionResult> GetHoaDonbySOHD(int soHD)
        {
            var HoaDon = await _HoaDonRepo.GetHoaDonAsyns(soHD);
            return HoaDon == null ? NotFound() : Ok(HoaDon);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewSanPham(HoaDonModel model)
        {
            try
            {
                var newHoaDonsoHD = await _HoaDonRepo.AddHoaDonAsyns(model);
                var HoaDon = await _HoaDonRepo.GetHoaDonAsyns(newHoaDonsoHD);
                return HoaDon == null ? NotFound() : Ok(HoaDon);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{soHD}")]
        public async Task<IActionResult> UpdateHoaDon(int soHD, HoaDonModel model)
        {
            if (soHD != model.SOHD)
            {
                return NotFound();
            }
            await _HoaDonRepo.UpdateHoaDonAsyns(soHD, model);
            return Ok();
        }
        [HttpDelete("{soHD}")]

        public async Task<IActionResult> DeleteHoaDon(int soHD)
        {
            await _HoaDonRepo.DeleteHoaDonAsyns(soHD);
            return Ok();
        }
    }
}
