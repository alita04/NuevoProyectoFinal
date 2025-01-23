
using AutoMapper;
using Enviromental_Measurement.Domain.Entities.Structures; 
using Enviromental_Variables_Measurement.GrpcProto; 


namespace Enviromental_Variable_Measurement.GrpcService.Mappers
{
    public class FloorProfile : Profile
    {
        public FloorProfile()
        {
            // Mapeo de Floor a FloorDTO
            CreateMap<Floor, FloorDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString())) // Convertir Guid a string
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.BuildingId, opt => opt.MapFrom(src => src.Building_Id.ToString())); // Convertir Guid a string

            // Mapeo de FloorDTO a Floor
            CreateMap<FloorDTO, Floor>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id))) // Convertir string a Guid
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.Building_Id, opt => opt.MapFrom(src => Guid.Parse(src.BuildingId))); // Convertir string a Guid
        }
    }
}