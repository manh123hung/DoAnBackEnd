using ShopBE.Web.API.Models;

namespace ShopBE.Web.API.Repositories
{
    public interface ISanPhamRepository
    {
        public Task<List<SanPhamModel>> GetAllSanPhamsAsyns();
        public Task<SanPhamModel> GetSanPhamAsyns(int maSP);
        public Task<int> AddSanPhamAsyns(SanPhamModel model);
        public Task UpdateSanPhamAsyns(int maSP, SanPhamModel model);
        public Task DeleteSanPhamAsyns(int maSP);
    }
}
