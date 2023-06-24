using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ServeMe_M2.Model;
using ServeMe_M2.Model.DTOs;
using ServeMe_M2.Model.RequestResponse;

namespace ServeMe_M2.Configurations
{
    public class MapperConfig : Profile
    {
       
        public MapperConfig()
        {
            CreateMap<ApiUser, ApiUserDto>().ReverseMap();
            CreateMap<RequestServiceDto, ServiceModel>().ReverseMap();
            CreateMap<VendorDto, VendorModel>().ReverseMap();
            CreateMap<VendorRegDto, VendorDto>().ReverseMap();
            CreateMap<QuotationTemplate, ServiceModel>().ReverseMap();
            
            
        }
    }
}
