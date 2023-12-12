using AutoMapper;
using ShopBE.Web.API.Data;
using ShopBE.Web.API.Models;

namespace ShopBE.Web.API.Helpers
{
    public class ShopMapper : Profile
    {
        public ShopMapper() { 
        CreateMap<SanPham,SanPhamModel>().ReverseMap();
            CreateMap<NhanVien, NhanVienModel>().ReverseMap();
            CreateMap<KhachHang, KhachHangModel>().ReverseMap();
            CreateMap<HoaDon, HoaDonModel>().ReverseMap();
            CreateMap<CTHD, CTHDModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
        }
    }
}
