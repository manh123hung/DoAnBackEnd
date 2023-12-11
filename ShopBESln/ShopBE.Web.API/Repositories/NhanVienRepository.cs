using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopBE.Web.API.Data;
using ShopBE.Web.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBE.Web.API.Repositories
{
    public class NhanVienRepository : INhanVienRepository
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public NhanVienRepository(ShopDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> AddNhanVienAsyns(NhanVienModel model)
        {
            try
            {
                var newNhanVien = _mapper.Map<NhanVien>(model);
                _context.NhanViens!.Add(newNhanVien);
                await _context.SaveChangesAsync();
                return newNhanVien.MANV;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi thêm nhân viên mới
                // Log lỗi hoặc thực hiện các bước xử lý lỗi khác tùy thuộc vào yêu cầu của bạn
                throw new Exception("Failed to add NhanVien. See inner exception for details.", ex);
            }
        }

        public async Task DeleteNhanVienAsyns(int maNV)
        {
            try
            {
                var deleteNhanVien = await _context.NhanViens.FindAsync(maNV);
                if (deleteNhanVien != null)
                {
                    _context.NhanViens.Remove(deleteNhanVien);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi xóa nhân viên
                throw new Exception("Failed to delete NhanVien. See inner exception for details.", ex);
            }
        }

        public async Task<List<NhanVienModel>> GetAllNhanViensAsyns()
        {
            try
            {
                var nhanviens = await _context.NhanViens.ToListAsync();
                return _mapper.Map<List<NhanVienModel>>(nhanviens);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi lấy tất cả nhân viên
                throw new Exception("Failed to get all NhanViens. See inner exception for details.", ex);
            }
        }

        public async Task<NhanVienModel> GetNhanVienAsyns(int maNV)
        {
            try
            {
                var nhanvien = await _context.NhanViens.FindAsync(maNV);
                return _mapper.Map<NhanVienModel>(nhanvien);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi lấy nhân viên theo ID
                throw new Exception($"Failed to get NhanVien with ID {maNV}. See inner exception for details.", ex);
            }
        }

        public async Task UpdateNhanVienAsyns(int maNV, NhanVienModel model)
        {
            try
            {
                if (maNV == model.MANV)
                {
                    var updateNhanVien = _mapper.Map<NhanVien>(model);
                    _context.NhanViens.Update(updateNhanVien);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi cập nhật nhân viên
                throw new Exception($"Failed to update NhanVien with ID {maNV}. See inner exception for details.", ex);
            }
        }
    }
}
