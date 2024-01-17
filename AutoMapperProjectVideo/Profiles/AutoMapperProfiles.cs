using AutoMapper;
using AutoMapperProjectVideo.Dto;
using AutoMapperProjectVideo.Models;

namespace AutoMapperProjectVideo.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap< LivroModel , LivroVisualizacaoDto>();
            CreateMap<LivroCriacaoDto, LivroModel  >();
        }
    }
}
