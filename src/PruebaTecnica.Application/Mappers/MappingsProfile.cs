using AutoMapper;
using PruebaTecnica.Application.Dtos;
using PruebaTecnica.Application.Services.Categoria.Commands.InsUpdCategoriaCommand;
using PruebaTecnica.Application.Services.Categoria.Queries;
using PruebaTecnica.Application.Services.Usuarios.Commands.AddUsuarioCommand;
using PruebaTecnica.Domain.Entities;

namespace PruebaTecnica.Application.Mappers
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<UsuarioDto, Usuario>().ReverseMap();

            CreateMap<AddUsuarioCommand, Usuario>().ReverseMap();
            CreateMap<InsUpdCategoriaCommand, Categorias>().ReverseMap();

            CreateMap<GetCategoriaAllFilterViewModel, Categorias>().ReverseMap();
        }
    }
}