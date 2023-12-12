using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopBE.Web.API.Models;
using ShopBE.Web.API.Repositories;

namespace ShopBE.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienRepository _nhanVienRepo;
        private readonly ILogger<NhanVienController> _logger;

        public NhanVienController(INhanVienRepository repo, ILogger<NhanVienController> logger)
        {
            _nhanVienRepo = repo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNhanViens()
        {
            try
            {
                _logger.LogInformation("Executing GetAllNhanViens");

                var result = await _nhanVienRepo.GetAllNhanViensAsyns();
                _logger.LogInformation($"Result: {result}");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllNhanViens");
                return BadRequest();
            }
        }

        [HttpGet("{maNV}")]
        public async Task<IActionResult> GetNhanVienbyMANV(int maNV)
        {
            try
            {
                _logger.LogInformation($"Executing GetNhanVienbyMANV with ID: {maNV}");

                var nhanVien = await _nhanVienRepo.GetNhanVienAsyns(maNV);
                _logger.LogInformation($"Result: {nhanVien}");

                return nhanVien == null ? NotFound() : Ok(nhanVien);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in GetNhanVienbyMANV with ID: {maNV}");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewNhanVien(NhanVienModel model)
        {
            try
            {
                _logger.LogInformation("Executing AddNewNhanVien");

                var newNhanVienMANV = await _nhanVienRepo.AddNhanVienAsyns(model);
                _logger.LogInformation($"New NhanVien MANV: {newNhanVienMANV}");

                var nhanVien = await _nhanVienRepo.GetNhanVienAsyns(newNhanVienMANV);
                _logger.LogInformation($"Result: {nhanVien}");

                return nhanVien == null ? NotFound() : Ok(nhanVien);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in AddNewNhanVien");
                return BadRequest();
            }
        }

        [HttpPut("{maNV}")]
        public async Task<IActionResult> UpdateNhanVien(int maNV, NhanVienModel model)
        {
            try
            {
                _logger.LogInformation($"Executing UpdateNhanVien with ID: {maNV}");

                if (maNV != model.MANV)
                {
                    _logger.LogWarning("ID mismatch in UpdateNhanVien");
                    return NotFound();
                }

                await _nhanVienRepo.UpdateNhanVienAsyns(maNV, model);
                _logger.LogInformation("UpdateNhanVien successful");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in UpdateNhanVien with ID: {maNV}");
                return BadRequest();
            }
        }

        [HttpDelete("{maNV}")]
        public async Task<IActionResult> DeleteNhanVien(int maNV)
        {
            try
            {
                _logger.LogInformation($"Executing DeleteNhanVien with ID: {maNV}");

                await _nhanVienRepo.DeleteNhanVienAsyns(maNV);
                _logger.LogInformation("DeleteNhanVien successful");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in DeleteNhanVien with ID: {maNV}");
                return BadRequest();
            }
        }
    }
}
