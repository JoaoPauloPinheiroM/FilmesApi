using System.ComponentModel.DataAnnotations;

namespace Filmes.Api.Data.DTos;

public class UpdateFilmeDto
{

    [Required(ErrorMessage = "o titulo do titulo é obrigatório")]
    public string Titulo { get; set; } = string.Empty;


    [Required(ErrorMessage = "O genero é obrigatorio")]
    [StringLength(50 , ErrorMessage = "O genero não pode exceder 50 caracteres")]
    public string Genero { get; set; }  = string.Empty;

    [Required]
    [Range(30 , 700 , ErrorMessage = "a duração precisa ter de 30 a 700 minutos")]
    public int Duracao { get; set; }
}
