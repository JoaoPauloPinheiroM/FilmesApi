using System.ComponentModel.DataAnnotations;

namespace Filmes.Api.Data.DTos;

public class ReadCinemaDto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
}
