using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopBE.Web.API.Data;
using ShopBE.Web.API.Models;

namespace ShopBE.Web.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(ShopDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> AddCategoryAsyns(CategoryModel model)
        {
            try
            {
                var newCategory = _mapper.Map<Category>(model);
                _context.Categories!.Add(newCategory);
                await _context.SaveChangesAsync();
                return newCategory.CATID;
            }
            catch (Exception ex)
            {
                // Handle error when adding a new customer
                throw new Exception("Failed to add Category. See inner exception for details.", ex);
            }
        }

        public async Task DeleteCategoryAsyns(int catID)
        {
            try
            {
                var deleteCategory = await _context.Categories.FindAsync(catID);
                if (deleteCategory != null)
                {
                    _context.Categories.Remove(deleteCategory);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle error when deleting a customer
                throw new Exception("Failed to delete Category. See inner exception for details.", ex);
            }
        }

        public async Task<List<CategoryModel>> GetAllCategorysAsyns()
        {
            try
            {
                var Categorys = await _context.Categories.ToListAsync();
                return _mapper.Map<List<CategoryModel>>(Categorys);
            }
            catch (Exception ex)
            {
                // Handle error when getting all customers
                throw new Exception("Failed to get all Category. See inner exception for details.", ex);
            }
        }

        public async Task<CategoryModel> GetCategoryAsyns(int catID)
        {
            try
            {
                var Category = await _context.Categories.FindAsync(catID);
                return _mapper.Map<CategoryModel>(Category);
            }
            catch (Exception ex)
            {
                // Handle error when getting a customer by ID
                throw new Exception($"Failed to get Category with ID {catID}. See inner exception for details.", ex);
            }
        }

        public async Task UpdateCategoryAsyns(int catID, CategoryModel model)
        {
            try
            {
                if (catID == model.CATID)
                {
                    var updateCategory = _mapper.Map<Category>(model);
                    _context.Categories.Update(updateCategory);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle error when updating a customer
                throw new Exception($"Failed to update CategoryModel with ID {catID}. See inner exception for details.", ex);
            }
        }
    }
}