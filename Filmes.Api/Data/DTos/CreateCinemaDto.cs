using System.ComponentModel.DataAnnotations;

namespace Filmes.Api.Data.DTos;

public class CreateCinemaDto
{
    [Required(ErrorMessage = "O campo nome é obrigatório.")]
    public string? Nome { get; set; }

    public int EnderecoId { get; set; }

}
