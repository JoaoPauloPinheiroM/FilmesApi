using AutoMapper;
using Filmes.Api.Data.DTos;
using Filmes.Api.Models;

namespace Filmes.Api.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile ()
    {
        CreateMap<CreateCinemaDto, Cinema>(); // destino <- origem
        CreateMap<Cinema, ReadCinemaDto>();
        CreateMap<UpdateCinemaDto, Cinema>(); 

    }
}
