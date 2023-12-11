using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBE.Web.API.Models;
using ShopBE.Web.API.Repositories;

namespace ShopBE.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamRepository _sanphamRepo;

        public SanPhamController(ISanPhamRepository repo)
        {
            _sanphamRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSanPhams()
        {
            try
            {
                return Ok(await _sanphamRepo.GetAllSanPhamsAsyns());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{maSP}")]
        public async Task<IActionResult> GetSanPhambyMaSP(int maSP)
        {
            var sanpham = await _sanphamRepo.GetSanPhamAsyns(maSP);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewSanPham(SanPhamModel model)
        {
            try
            {
                var newSanPhamMaSP = await _sanphamRepo.AddSanPhamAsyns(model);
                var sanpham = await _sanphamRepo.GetSanPhamAsyns(newSanPhamMaSP);
                return sanpham == null ? NotFound() : Ok(sanpham);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{maSP}")]
        public async Task<IActionResult> UpdateSanPham(int maSP, SanPhamModel model)
        {
            if (maSP != model.MaSP)
            {
                return NotFound();
            }
            await _sanphamRepo.UpdateSanPhamAsyns(maSP, model);
            return Ok();
        }
        [HttpDelete("{maSP}")]
        
        public async Task<IActionResult> DeleteSanPham(int maSP)
        {
            await _sanphamRepo.DeleteSanPhamAsyns(maSP);
            return Ok();
        }
    }
}
