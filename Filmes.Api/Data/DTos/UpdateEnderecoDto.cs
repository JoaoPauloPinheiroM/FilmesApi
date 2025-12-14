using System.ComponentModel.DataAnnotations;

namespace Filmes.Api.Data.DTos;

public class UpdateEnderecoDto
{
    public string Logradouro { get; set; }

    public int numero { get; set; }

}
