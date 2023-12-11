using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopBE.Web.API.Data;
using ShopBE.Web.API.Models;
using System;

namespace ShopBE.Web.API.Repositories
{
    public class KhachHangRepository : IKhachHangRepository
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public KhachHangRepository(ShopDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> AddKhachHangAsyns(KhachHangModel model)
        {
            try
            {
                var newKhachHang = _mapper.Map<KhachHang>(model);
                _context.KhachHangs!.Add(newKhachHang);
                await _context.SaveChangesAsync();
                return newKhachHang.MAKH;
            }
            catch (Exception ex)
            {
                // Handle error when adding a new customer
                throw new Exception("Failed to add KhachHang. See inner exception for details.", ex);
            }
        }

        public async Task DeleteKhachHangAsyns(int maKH)
        {
            try
            {
                var deleteKhachHang = await _context.KhachHangs.FindAsync(maKH);
                if (deleteKhachHang != null)
                {
                    _context.KhachHangs.Remove(deleteKhachHang);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle error when deleting a customer
                throw new Exception("Failed to delete KhachHang. See inner exception for details.", ex);
            }
        }

        public async Task<List<KhachHangModel>> GetAllKhachHangsAsyns()
        {
            try
            {
                var khachangs = await _context.KhachHangs.ToListAsync();
                return _mapper.Map<List<KhachHangModel>>(khachangs);
            }
            catch (Exception ex)
            {
                // Handle error when getting all customers
                throw new Exception("Failed to get all KhachHangS. See inner exception for details.", ex);
            }
        }

        public async Task<KhachHangModel> GetKhachHangAsyns(int maKH)
        {
            try
            {
                var khachhang = await _context.KhachHangs.FindAsync(maKH);
                return _mapper.Map<KhachHangModel>(khachhang);
            }
            catch (Exception ex)
            {
                // Handle error when getting a customer by ID
                throw new Exception($"Failed to get khachhang with ID {maKH}. See inner exception for details.", ex);
            }
        }

        public async Task UpdateKhachHangAsyns(int maKH, KhachHangModel model)
        {
            try
            {
                if (maKH == model.MAKH)
                {
                    var updateKhachHang = _mapper.Map<KhachHang>(model);
                    _context.KhachHangs.Update(updateKhachHang);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle error when updating a customer
                throw new Exception($"Failed to update KhachHangModel with ID {maKH}. See inner exception for details.", ex);
            }
        }
    }
}
