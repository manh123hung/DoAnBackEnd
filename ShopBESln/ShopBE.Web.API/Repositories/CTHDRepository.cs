using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopBE.Web.API.Data;
using ShopBE.Web.API.Models;

namespace ShopBE.Web.API.Repositories
{
    public class CTHDRepository : ICTHDRepository
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public CTHDRepository(ShopDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> AddCTHDAsyns(CTHDModel model)
        {
            try
            {
                var newCTHD = _mapper.Map<CTHD>(model);
                _context.CTHDs!.Add(newCTHD);
                await _context.SaveChangesAsync();
                return newCTHD.SOHD;
            }
            catch (Exception ex)
            {
                // Handle error when adding a new customer
                throw new Exception("Failed to add CTHD. See inner exception for details.", ex);
            }
        }

        public async Task DeleteCTHDAsyns(int soHD)
        {
            try
            {
                var deleteCTHD = await _context.CTHDs.FindAsync(soHD);
                if (deleteCTHD != null)
                {
                    _context.CTHDs.Remove(deleteCTHD);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle error when deleting a customer
                throw new Exception("Failed to delete CTHD. See inner exception for details.", ex);
            }
        }

        public async Task<List<CTHDModel>> GetAllCTHDsAsyns()
        {
            try
            {
                var CTHDs = await _context.CTHDs.ToListAsync();
                return _mapper.Map<List<CTHDModel>>(CTHDs);
            }
            catch (Exception ex)
            {
                // Handle error when getting all customers
                throw new Exception("Failed to get all CTHD. See inner exception for details.", ex);
            }
        }

        public async Task<CTHDModel> GetCTHDAsyns(int soHD)
        {
            try
            {
                var CTHD = await _context.CTHDs.FindAsync(soHD);
                return _mapper.Map<CTHDModel>(CTHD);
            }
            catch (Exception ex)
            {
                // Handle error when getting a customer by ID
                throw new Exception($"Failed to get CTHD with ID {soHD}. See inner exception for details.", ex);
            }
        }

        public async Task UpdateCTHDAsyns(int soHD, CTHDModel model)
        {
            try
            {
                if (soHD == model.SOHD)
                {
                    var updateCTHD = _mapper.Map<CTHD>(model);
                    _context.CTHDs.Update(updateCTHD);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle error when updating a customer
                throw new Exception($"Failed to update CTHDModel with ID {soHD}. See inner exception for details.", ex);
            }
        }
    }
}


