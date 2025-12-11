namespace Filmes.Api.Context.DTos;

public class ReadFilmeDto
{


    public string Titulo { get; set; } = string.Empty;


    public string Genero { get; set; } = string.Empty;


    public int Duracao { get; set; }

    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}
