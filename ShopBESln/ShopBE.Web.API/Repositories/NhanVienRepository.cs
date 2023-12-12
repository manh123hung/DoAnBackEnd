using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopBE.Web.API.Data;
using ShopBE.Web.API.Models;

namespace ShopBE.Web.API.Repositories
{
    public class NhanVienRepository : INhanVienRepository
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public NhanVienRepository(ShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddNhanVienAsyns(NhanVienModel model)
        {
            var newNhanVien = _mapper.Map<NhanVien>(model);
            _context.NhanViens!.Add(newNhanVien);
            await _context.SaveChangesAsync();
            return newNhanVien.MANV;
        }

        public async Task DeleteNhanVienAsyns(int maNV)
        {
            var deleteNhanVien = _context.NhanViens.SingleOrDefault(nv => nv.MANV == maNV);
            if (deleteNhanVien != null)
            {
                _context.NhanViens!.Remove(deleteNhanVien);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<NhanVienModel>> GetAllNhanViensAsyns()
        {
            var nhanViens = await _context.NhanViens!.ToListAsync();
            return _mapper.Map<List<NhanVienModel>>(nhanViens);
        }

        public async Task<NhanVienModel> GetNhanVienAsyns(int maNV)
        {
            var nhanViens = await _context.NhanViens!.FindAsync(maNV);
            return _mapper.Map<NhanVienModel>(nhanViens);
        }

        public async Task UpdateNhanVienAsyns(int maNV, NhanVienModel model)
        {
            if (maNV == model.MANV)
            {
                var updateNhanVien = _mapper.Map<NhanVien>(model);
                _context.NhanViens!.Update(updateNhanVien);
                await _context.SaveChangesAsync();

            }
        }
    }
}
