using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Filmes.Api.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get;  set; }

    [Required(ErrorMessage ="o titulo do titulo é obrigatório")]
    public string Titulo {  get; set; }


    [Required ( ErrorMessage = "O genero é obrigatorio")]
    [MaxLength(50, ErrorMessage = "O genero não pode exceder 50 caracteres")]
    public string Genero { get; set; }

    [Required]
    [Range(30, 700, ErrorMessage ="a duração precisa ter de 30 a 700 minutos")]
    public int Duracao { get; set; }
}
