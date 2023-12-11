using ShopBE.Web.API.Models;
namespace ShopBE.Web.API.Repositories
{
    public interface INhanVienRepository
    {
        public Task<List<NhanVienModel>> GetAllNhanViensAsyns();
        public Task<NhanVienModel> GetNhanVienAsyns(int maNV);
        public Task<int> AddNhanVienAsyns(NhanVienModel model);
        public Task UpdateNhanVienAsyns(int maNV, NhanVienModel model);
        public Task DeleteNhanVienAsyns(int maNV);
    }
}
