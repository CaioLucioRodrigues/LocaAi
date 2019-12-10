using AutoMapper;
using LocaAi.Domain.Entities;
using LocaAi.Presentation.Site.ViewModels;

namespace LocaAi.Presentation.Site.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
        }
    }
}
