using Filmes.Api.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Api.Data;

public class FilmeContext : DbContext
{
    public FilmeContext ( DbContextOptions<FilmeContext> options ) : base ( options)
    {

    }
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
}
