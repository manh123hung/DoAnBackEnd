using ShopBE.Web.API.Models;

namespace ShopBE.Web.API.Repositories
{
    public interface ICategoryRepository
    {
        public Task<List<CategoryModel>> GetAllCategorysAsyns();
        public Task<CategoryModel> GetCategoryAsyns(int catID);
        public Task<int> AddCategoryAsyns(CategoryModel model);
        public Task UpdateCategoryAsyns(int catID, CategoryModel model);
        public Task DeleteCategoryAsyns(int catID);
    }
}
