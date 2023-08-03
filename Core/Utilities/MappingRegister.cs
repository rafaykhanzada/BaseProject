using AutoMapper;
using Core.Data.DTO;
using Core.Data.DTOs;
using Core.Data.Entities;

namespace Core.Utilities
{
    public class MappingRegister
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Checkpoints, CheckpointsDTO>().ReverseMap();
                config.CreateMap<CPClass, CPClassDTO>().ReverseMap();
                config.CreateMap<CPDeviation, CPDeviationDTO>().ReverseMap();
                config.CreateMap<Auditor, AuditorDTO>().ReverseMap();
                config.CreateMap<Email, EmailDTO>().ReverseMap();
                config.CreateMap<FaultGroup, FaultGroupDTO>().ReverseMap();
                config.CreateMap<Shift, ShiftDTO>().ReverseMap();
                config.CreateMap<Model, ModelDTO>().ReverseMap();
                config.CreateMap<Variant, VariantDTO>().ReverseMap();
                config.CreateMap<AuditType, AuditTypeDTO>().ReverseMap();
                config.CreateMap<Product, ProductDTO>().ReverseMap();
                config.CreateMap<Plant, PlantDTO>().ReverseMap();
                config.CreateMap<Zone, ZoneDTO>().ReverseMap();
                config.CreateMap<Category, CategoryDTO>().ReverseMap();
                config.CreateMap<User, UserVM>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}
