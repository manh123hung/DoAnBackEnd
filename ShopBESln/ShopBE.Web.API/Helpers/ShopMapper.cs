using AutoMapper;
using ShopBE.Web.API.Data;
using ShopBE.Web.API.Models;

namespace ShopBE.Web.API.Helpers
{
    public class ShopMapper : Profile
    {
        public ShopMapper() { 
        CreateMap<SanPham,SanPhamModel>().ReverseMap();
        }
    }
}
