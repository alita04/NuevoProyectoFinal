
using AutoMapper;
using EMV.Domain.Entities.Structures; 
using EMV.GrpcProto; 

namespace EMV.GrpcService1.Mappers
{
    public class BuildingProfile : Profile
    {
        public BuildingProfile()
        {
            // Mapeo de Building a BuildingDTO
            CreateMap<Building, BuildingDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString())) // Convertir Guid a string
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new PhysicalAddress
                {
                    Country = src.Address.Country,
                    City = src.Address.City,
                    Address = src.Address.Address
                }))
                .ForMember(dest => dest.BuildingNumber, opt => opt.MapFrom(src => src.BuildingNumber));

            // Mapeo de BuildingDTO a Building
            CreateMap<BuildingDTO, Building>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id))) // Convertir string a Guid
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new PhysicalAddress
                {
                    Country = src.Address.Country,
                    City = src.Address.City,
                    Address = src.Address.Address
                }))
                .ForMember(dest => dest.BuildingNumber, opt => opt.MapFrom(src => src.BuildingNumber));
        }
    }
}