using AutoMapper;
using Filmes.Api.Data.DTos;
using Filmes.Api.Models;

namespace Filmes.Api.Profiles;

public class SessaoProfile : Profile    
{
    public SessaoProfile ()
    {
        CreateMap<CreateSessaoDto, Sessao>(); // destino <- origem
        CreateMap<Sessao, ReadSessaoDto>();
    }
}
