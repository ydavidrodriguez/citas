using AutoMapper;
using Citas.Application.RequestManager.Commands;
using Citas.Domain.Dto;

namespace Citas.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Domain.Entities.Citas, PostCreateCitasRequest>().ReverseMap();
            CreateMap<Domain.Entities.Citas, PutUpdateCitasRequest>().ReverseMap();
        }

    }
}
