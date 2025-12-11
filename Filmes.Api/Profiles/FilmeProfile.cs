using AutoMapper;
using Filmes.Api.Context.DTos;
using Filmes.Api.Models;

namespace Filmes.Api.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile ()
    {
        CreateMap<CreateFilmeDto , Filme>();
        CreateMap<UpdateFilmeDto , Filme>();
        CreateMap<Filme , UpdateFilmeDto>();
        CreateMap<Filme , ReadFilmeDto>();

    }
}
