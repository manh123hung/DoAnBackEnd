using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopBE.Web.API.Data;
using ShopBE.Web.API.Models;

namespace ShopBE.Web.API.Repositories
{
    public class HoaDonRepository : IHoaDonRepository
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public HoaDonRepository(ShopDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> AddHoaDonAsyns(HoaDonModel model)
        {
            try
            {
                var newHoaDon = _mapper.Map<HoaDon>(model);
                _context.HoaDons!.Add(newHoaDon);
                await _context.SaveChangesAsync();
                return newHoaDon.SOHD;
            }
            catch (Exception ex)
            {
                // Handle error when adding a new customer
                throw new Exception("Failed to add HoaDon. See inner exception for details.", ex);
            }
        }

        public async Task DeleteHoaDonAsyns(int soHD)
        {
            try
            {
                var deleteHoaDon = await _context.HoaDons.FindAsync(soHD);
                if (deleteHoaDon != null)
                {
                    _context.HoaDons.Remove(deleteHoaDon);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle error when deleting a customer
                throw new Exception("Failed to delete HoaDon. See inner exception for details.", ex);
            }
        }

        public async Task<List<HoaDonModel>> GetAllHoaDonsAsyns()
        {
            try
            {
                var hoadons = await _context.HoaDons.ToListAsync();
                return _mapper.Map<List<HoaDonModel>>(hoadons);
            }
            catch (Exception ex)
            {
                // Handle error when getting all customers
                throw new Exception("Failed to get all HoaDon. See inner exception for details.", ex);
            }
        }

        public async Task<HoaDonModel> GetHoaDonAsyns(int soHD)
        {
            try
            {
                var hoadon = await _context.HoaDons.FindAsync(soHD);
                return _mapper.Map<HoaDonModel>(hoadon);
            }
            catch (Exception ex)
            {
                // Handle error when getting a customer by ID
                throw new Exception($"Failed to get HoaDon with ID {soHD}. See inner exception for details.", ex);
            }
        }

        public async Task UpdateHoaDonAsyns(int soHD, HoaDonModel model)
        {
            try
            {
                if (soHD == model.SOHD)
                {
                    var updateHoaDon = _mapper.Map<HoaDon>(model);
                    _context.HoaDons.Update(updateHoaDon);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle error when updating a customer
                throw new Exception($"Failed to update HoaDonModel with ID {soHD}. See inner exception for details.", ex);
            }
        }
    }
}

