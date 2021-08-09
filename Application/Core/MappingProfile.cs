using Application.Businesses;
using Application.Dtos;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Business, Business>();
            CreateMap<Business, BusinessDto>();
            CreateMap<BusinessDto, Business>();
            CreateMap<Phone, Phone>();
            CreateMap<Phone, PhoneDto>();
            CreateMap<PhoneDto, Phone>();
            CreateMap<Address, Address>();
            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();
        }
    }
}