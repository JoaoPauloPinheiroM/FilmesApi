using AutoMapper;
using Filmes.Api.Data.DTos;
using Filmes.Api.Models;

namespace Filmes.Api.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile ()
    {

        //         origem               destino
        CreateMap<CreateEnderecoDto , Endereco>();
        //         origem               destino
        CreateMap<Endereco , ReadEnderecoDto>();
        //         origem               destino
        CreateMap<UpdateCinemaDto , Endereco>(); 

    }
}

