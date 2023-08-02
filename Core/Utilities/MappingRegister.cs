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
                config.CreateMap<Category, CategoryDTO>().ReverseMap();
                config.CreateMap<User, UserVM>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}
