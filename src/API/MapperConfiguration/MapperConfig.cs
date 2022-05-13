using API.DTO.Request;
using API.DTO.Response;
using Data.Caching.Replicas;
using AutoMapper;
using Domain.Entities;

namespace API.MapperConfiguration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ClasseExemploRequestDTO, ClasseExemplo>().ReverseMap();

            CreateMap<ClasseExemplo, ClasseExemploResponse>();
            CreateMap(typeof(EntidadePaginate<>), typeof(ClasseExemploResponseDTO<>));
            CreateMap<ClasseExemplo, ClasseExemploReplica>();
        }
    }
}
