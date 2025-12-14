using System.ComponentModel.DataAnnotations;

namespace Filmes.Api.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }

    public string Logradouro { get; set; }

    public int numero { get; set; }

    public virtual Cinema? Cinema { get; set; }

}
