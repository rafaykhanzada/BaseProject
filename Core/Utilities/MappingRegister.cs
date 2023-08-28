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
                config.CreateMap<CheckpointClasses, CPClassDTO>().ReverseMap();
                config.CreateMap<CheckpointDeviations, CPDeviationDTO>().ReverseMap();
                config.CreateMap<Auditors, AuditorDTO>().ReverseMap();
                config.CreateMap<Email, EmailDTO>().ReverseMap();
                config.CreateMap<FaultGroups, FaultGroupDTO>().ReverseMap();
                config.CreateMap<Shifts, ShiftDTO>().ReverseMap();
                config.CreateMap<Models, ModelDTO>().ReverseMap();
                config.CreateMap<Variants, VariantDTO>().ReverseMap();
                config.CreateMap<AuditTypes, AuditTypeDTO>().ReverseMap();
                config.CreateMap<Products, ProductDTO>().ReverseMap();
                config.CreateMap<ProductDTO, Products>().ReverseMap();
                config.CreateMap<Plants, PlantDTO>().ReverseMap();
                config.CreateMap<ZoneOrStations, ZoneDTO>().ReverseMap();
                config.CreateMap<Category, CategoryDTO>().ReverseMap();
                config.CreateMap<Users, UserVM>().ReverseMap();
                config.CreateMap<Permission, PermissionVM>().ReverseMap();
                config.CreateMap<Menu, MenuVM>().ReverseMap();
                config.CreateMap<Role, RoleVM>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}
