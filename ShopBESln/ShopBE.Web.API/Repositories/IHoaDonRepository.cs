using ShopBE.Web.API.Models;

namespace ShopBE.Web.API.Repositories
{
    public interface IHoaDonRepository
    {
        public Task<List<HoaDonModel>> GetAllHoaDonsAsyns();
        public Task<HoaDonModel> GetHoaDonAsyns(int soHD);
        public Task<int> AddHoaDonAsyns(HoaDonModel model);
        public Task UpdateHoaDonAsyns(int soHD, HoaDonModel model);
        public Task DeleteHoaDonAsyns(int soHD);
    }
}
