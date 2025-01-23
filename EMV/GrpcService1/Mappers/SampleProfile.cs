
using AutoMapper;
using EMV.Domain.Entities.Samples; 
using EMV.GrpcProtos; 

using Google.Protobuf.WellKnownTypes; // Para manejar Timestamp

namespace EMV.GrpcService1.Mappers
{
    public class SampleProfile : Profile
    {
        public SampleProfile()
        {
            // Mapeo de Sample a SampleDTO
            CreateMap<Sample, SampleDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString())) // Convertir Guid a string
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => Timestamp.FromDateTime(src.DateTime.ToUniversalTime()))) // Convertir DateTime a Timestamp
                .ForMember(dest => dest.VariableId, opt => opt.MapFrom(src => src.VariableId.ToString())) // Convertir Guid a string
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.type)) // Mapeo directo de SampleType
                .ForMember(dest => dest.DecimalValue, opt => opt.MapFrom(src => src.DecimalValue))
                .ForMember(dest => dest.IntValue, opt => opt.MapFrom(src => src.IntValue))
                .ForMember(dest => dest.BoolValue, opt => opt.MapFrom(src => src.BoolValue));

            // Mapeo de SampleDTO a Sample
            CreateMap<SampleDTO, Sample>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id))) // Convertir string a Guid
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime.ToDateTime())) // Convertir Timestamp a DateTime
                .ForMember(dest => dest.VariableId, opt => opt.MapFrom(src => Guid.Parse(src.VariableId))) // Convertir string a Guid
                .ForMember(dest => dest.type, opt => opt.MapFrom(src => src.Type)) // Mapeo directo de SampleType
                .ForMember(dest => dest.DecimalValue, opt => opt.MapFrom(src => src.DecimalValue))
                .ForMember(dest => dest.IntValue, opt => opt.MapFrom(src => src.IntValue))
                .ForMember(dest => dest.BoolValue, opt => opt.MapFrom(src => src.BoolValue));
        }
    }
}