using ShopBE.Web.API.Models;

namespace ShopBE.Web.API.Repositories
{
    public interface ICTHDRepository
    {
        public Task<List<CTHDModel>> GetAllCTHDsAsyns();
        public Task<CTHDModel> GetCTHDAsyns(int soHD);
        public Task<int> AddCTHDAsyns(CTHDModel model);
        public Task UpdateCTHDAsyns(int soHD, CTHDModel model);
        public Task DeleteCTHDAsyns(int soHD);
    }
}
