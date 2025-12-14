using System.ComponentModel.DataAnnotations;

namespace Filmes.Api.Data.DTos;

public class ReadEnderecoDto
{
    [Key]
    [Required]
    public int Id { get; set; }

    public string Logradouro { get; set; }

    public int numero { get; set; }

}
