using AutoMapper;
using PartTwo.Entities.DTOs;
using PartTwo.Entities.DTOs.User;
using PartTwo.Entities.Entities;
using PartTwo.Entities.Entities.Identity;

namespace PartTwo.WebAPI.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductToReturnDto>()
                .ForMember(dest => dest.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<ProductUrlResolver>());

        CreateMap<Address, AddressDto>().ReverseMap();
    }
}
