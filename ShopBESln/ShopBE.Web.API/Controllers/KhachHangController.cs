using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBE.Web.API.Models;
using ShopBE.Web.API.Repositories;

namespace ShopBE.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangRepository _khachhangRepo;

        public KhachHangController(IKhachHangRepository repo)
        {
            _khachhangRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllKhachHangs()
        {
            try
            {
                return Ok(await _khachhangRepo.GetAllKhachHangsAsyns());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{maKH}")]
        public async Task<IActionResult> GetKhachHangbymaKH(int maKH)
        {
            var  khachhang= await _khachhangRepo.GetKhachHangAsyns(maKH);
            return khachhang == null ? NotFound() : Ok(khachhang);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewSanPham(KhachHangModel model)
        {
            try
            {
                var newKhachHangmaKH = await _khachhangRepo.AddKhachHangAsyns(model);
                var khachhang = await _khachhangRepo.GetKhachHangAsyns(newKhachHangmaKH);
                return khachhang == null ? NotFound() : Ok(khachhang);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{maKH}")]
        public async Task<IActionResult> UpdateKhachHang(int maKH, KhachHangModel model)
        {
            if (maKH != model.MAKH)
            {
                return NotFound();
            }
            await _khachhangRepo.UpdateKhachHangAsyns(maKH, model);
            return Ok();
        }
        [HttpDelete("{maKH}")]

        public async Task<IActionResult> DeleteKhachHang(int maKH)
        {
            await _khachhangRepo.DeleteKhachHangAsyns(maKH);
            return Ok();
        }
    }
}
