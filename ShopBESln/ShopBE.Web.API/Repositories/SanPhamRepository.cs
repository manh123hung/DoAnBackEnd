using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopBE.Web.API.Data;
using ShopBE.Web.API.Models;

namespace ShopBE.Web.API.Repositories
{
    public class SanPhamRepository : ISanPhamRepository
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public SanPhamRepository(ShopDbContext context,IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddSanPhamAsyns(SanPhamModel model)
        {
        var newSanPham=_mapper.Map<SanPham>(model);
            _context.SanPhams!.Add(newSanPham);
            await _context.SaveChangesAsync();
            return newSanPham.MaSP;
        }

        public async Task DeleteSanPhamAsyns(int maSP)
        {
            var deleteSanPham = _context.SanPhams.SingleOrDefault(sp => sp.MaSP == maSP);
            if (deleteSanPham!=null)
            {
                _context.SanPhams!.Remove(deleteSanPham);
                await _context.SaveChangesAsync() ;
            }
        }

        public async Task<List<SanPhamModel>> GetAllSanPhamsAsyns()
        {
            var sanphams = await _context.SanPhams!.ToListAsync();
            return _mapper.Map<List<SanPhamModel>>(sanphams);
        }

        public async Task<SanPhamModel> GetSanPhamAsyns(int maSP)
        {
            var sanphams = await _context.SanPhams!.FindAsync(maSP);
            return _mapper.Map<SanPhamModel>(sanphams);
        }

        public async Task UpdateSanPhamAsyns(int maSP, SanPhamModel model)
        {
           if(maSP== model.MaSP)
            {
                var updateSanPham = _mapper.Map<SanPham>(model);
                _context.SanPhams!.Update(updateSanPham);
                await _context.SaveChangesAsync();
                
            }
        }
    }
}
