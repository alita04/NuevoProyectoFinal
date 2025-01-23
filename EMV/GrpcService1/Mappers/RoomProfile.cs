
using AutoMapper;
using Enviromental_Measurement.Domain.Entities.Structures; 
using Enviromental_Variables_Measurement.GrpcProto; 


namespace Enviromental_Variable_Measurement.GrpcService.Mappers
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            // Mapeo de Room a RoomDTO
            CreateMap<Room, RoomDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString())) // Convertir Guid a string
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.IsProduction, opt => opt.MapFrom(src => src.IsProduction))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.FloorId, opt => opt.MapFrom(src => src.FloorId.ToString())); // Convertir Guid a string

            // Mapeo de RoomDTO a Room
            CreateMap<RoomDTO, Room>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id))) // Convertir string a Guid
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.IsProduction, opt => opt.MapFrom(src => src.IsProduction))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.FloorId, opt => opt.MapFrom(src => Guid.Parse(src.FloorId))); // Convertir string a Guid
        }
    }
}