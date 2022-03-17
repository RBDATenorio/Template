using API.DTO.Request;
using AutoMapper;
using Domain.Entities;

namespace API.MapperConfiguration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ClasseExemploRequestDTO, ClasseExemplo>().ReverseMap();
        }
    }
}
