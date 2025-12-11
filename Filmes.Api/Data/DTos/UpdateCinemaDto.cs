using System.ComponentModel.DataAnnotations;

namespace Filmes.Api.Data.DTos;

public class UpdateCinemaDto
{
    [Required(ErrorMessage = "O campo nome é obrigatório.")]
    public string? Nome { get; set; }
}
