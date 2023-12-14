using System;
using System.IO;
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
        public async Task<IActionResult> AddNewSanPham([FromForm] SanPhamModel model, IFormFile image)
        {
            try
            {
                if (model == null || image == null || image.Length == 0)
                {
                    return BadRequest("Invalid model or image");
                }

                // Xử lý tệp hình ảnh
                model.Image = await WriteFile(image);

                var newSanPhamMaSP = await _sanphamRepo.AddSanPhamAsyns(model);
                var sanpham = await _sanphamRepo.GetSanPhamAsyns(newSanPhamMaSP);

                return sanpham == null ? NotFound() : Ok(sanpham);
            }
            catch (Exception)
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

        private async Task<string> WriteFile(IFormFile image)
        {
            string filename = "";
            try
            {
                var extension = "." + image.FileName.Split('.')[image.FileName.Split('.').Length - 1];
                filename = DateTime.Now.Ticks.ToString() + extension;

                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", filename);
                using (var stream = new FileStream(exactpath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
            }
            catch (Exception)
            {
                // Xử lý lỗi nếu cần
            }
            return filename;
        }
    }
}
