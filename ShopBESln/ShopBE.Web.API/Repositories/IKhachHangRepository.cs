using ShopBE.Web.API.Models;
namespace ShopBE.Web.API.Repositories
{
    public interface IKhachHangRepository
    {
        public Task<List<KhachHangModel>> GetAllKhachHangsAsyns();
        public Task<KhachHangModel> GetKhachHangAsyns(int maKH);
        public Task<int> AddKhachHangAsyns(KhachHangModel model);
        public Task UpdateKhachHangAsyns(int maKH, KhachHangModel model);
        public Task DeleteKhachHangAsyns(int maKH);
    }
}
