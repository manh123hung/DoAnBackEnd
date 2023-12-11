using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBE.Web.API.Models;
using ShopBE.Web.API.Repositories;

namespace ShopBE.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienRepository _nhanvienRepo;

        public NhanVienController(INhanVienRepository repo)
        {
            _nhanvienRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllNhanViens()
        {
            try
            {
                return Ok(await _nhanvienRepo.GetAllNhanViensAsyns());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{maNV}")]
        public async Task<IActionResult> GetNhanVienbyMaNV(int maNV)
        {
            var nhanvien = await _nhanvienRepo.GetNhanVienAsyns(maNV);
            return nhanvien == null ? NotFound() : Ok(nhanvien);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewSanPham(NhanVienModel model)
        {
            try
            {
                var newNhanVienMaNV = await _nhanvienRepo.AddNhanVienAsyns(model);
                var nhanvien = await _nhanvienRepo.GetNhanVienAsyns(newNhanVienMaNV);
                return nhanvien == null ? NotFound() : Ok(nhanvien);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{maNV}")]
        public async Task<IActionResult> UpdateNhanVien(int maNV, NhanVienModel model)
        {
            if (maNV != model.MANV)
            {
                return NotFound();
            }
            await _nhanvienRepo.UpdateNhanVienAsyns(maNV, model);
            return Ok();
        }
        [HttpDelete("{maNV}")]

        public async Task<IActionResult> DeleteNhanVien(int maNV)
        {
            await _nhanvienRepo.DeleteNhanVienAsyns(maNV);
            return Ok();
        }
    }
}
