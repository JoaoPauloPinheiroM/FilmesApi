using System.ComponentModel.DataAnnotations;

namespace Filmes.Api.Data.DTos;

public class CreateEnderecoDto
{

    public string Logradouro { get; set; }

    public int numero { get; set; }
}
