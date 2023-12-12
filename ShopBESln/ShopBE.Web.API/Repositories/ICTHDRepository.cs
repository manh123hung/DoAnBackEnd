using ShopBE.Web.API.Models;

namespace ShopBE.Web.API.Repositories
{
    public interface ICTHDRepository
    {
        public Task<List<CTHDModel>> GetAllCTHDsAsyns();
        public Task<CTHDModel> GetCTHDAsyns(int ctID);
        public Task<int> AddCTHDAsyns(CTHDModel model);
        public Task UpdateCTHDAsyns(int ctID, CTHDModel model);
        public Task DeleteCTHDAsyns(int ctID);
    }
}
