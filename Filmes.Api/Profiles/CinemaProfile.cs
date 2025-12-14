using AutoMapper;
using Filmes.Api.Data.DTos;
using Filmes.Api.Models;

namespace Filmes.Api.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile ()
    {
        CreateMap<CreateCinemaDto, Cinema>(); // destino <- origem
        CreateMap<Cinema, ReadCinemaDto>().ForMember(Cinemadto => Cinemadto.Endereco, opt => opt.MapFrom(cinema => cinema.Endereco));
        CreateMap<UpdateCinemaDto, Cinema>();
        CreateMap<Cinema , ReadCinemaDto>().ForMember(Cinemadto => Cinemadto.Sessoes , opt => opt.MapFrom(cinema => cinema.Sessoes));

    }
}
