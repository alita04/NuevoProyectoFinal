
using AutoMapper;
using EMV.Domain.Entities.Variable;
using EMV.Domain.ValueObjects;
using EMV.GrpcProto;


namespace EMV.GrpcService1.Mappers
{
    public class VariableProfile : Profile
    {
        public VariableProfile()
        {
            // Mapeo de Variable a VariableDTO
            CreateMap<Variable, VariableDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString())) // Convertir Guid a string
                .ForMember(dest => dest.VariableName, opt => opt.MapFrom(src => src.VariableName))
                .ForMember(dest => dest.MeasurementUnit, opt => opt.MapFrom(src => new MeasurementUnit
                {
                    Symbol = src.unit.Symbol,
                    Name = src.unit.Name
                }))
                .ForMember(dest => dest.VariableCode, opt => opt.MapFrom(src => src.VariableCode))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.type)) // Mapeo directo de VariableType
                .ForMember(dest => dest.BuildingID, opt => opt.MapFrom(src => src.BuildingID.HasValue ? src.BuildingID.Value.ToString() : null)) // Convertir Guid a string
                .ForMember(dest => dest.FloorID, opt => opt.MapFrom(src => src.FloorID.HasValue ? src.FloorID.Value.ToString() : null)) // Convertir Guid a string
                .ForMember(dest => dest.RoomID, opt => opt.MapFrom(src => src.RoomID.HasValue ? src.RoomID.Value.ToString() : null)); // Convertir Guid a string

            // Mapeo de VariableDTO a Variable
            CreateMap<VariableDTO, Variable>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id))) // Convertir string a Guid
                .ForMember(dest => dest.VariableName, opt => opt.MapFrom(src => src.VariableName))
                .ForMember(dest => dest.unit, opt => opt.MapFrom(src => new Measurement_Unit(src.MeasurementUnit.Symbol, src.MeasurementUnit.Name)))
                .ForMember(dest => dest.VariableCode, opt => opt.MapFrom(src => src.VariableCode))
                .ForMember(dest => dest.type, opt => opt.MapFrom(src => src.Type)) // Mapeo directo de VariableType
                .ForMember(dest => dest.BuildingID, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.BuildingID) ? (Guid?)null : Guid.Parse(src.BuildingID))) // Convertir string a Guid
                .ForMember(dest => dest.FloorID, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.FloorID) ? (Guid?)null : Guid.Parse(src.FloorID))) // Convertir string a Guid
                .ForMember(dest => dest.RoomID, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.RoomID) ? (Guid?)null : Guid.Parse(src.RoomID))); // Convertir string a Guid
        }
    }
}