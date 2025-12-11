using AutoMapper;
using Filmes.Api.Context;
using Filmes.Api.Context.DTos;
using Filmes.Api.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmeController : ControllerBase
{

    private readonly FilmeContext _context;
    private readonly IMapper _mapper;
    public FilmeController ( FilmeContext filmeContext, IMapper mapper)
    {
        _context = filmeContext;
        _mapper = mapper;
    }


    /// <summary>
    /// Creates a new film resource using the specified data and returns a response indicating the resource was created.
    /// </summary>
    /// <remarks>The response includes a Location header pointing to the URI of the newly created film. If the
    /// operation succeeds, the film is persisted in the database.</remarks>
    /// <param name="filmeDto">The data transfer object containing the details of the film to add. Must not be null.</param>
    /// <returns>A 201 Created response containing the newly created film and the location of the resource.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);

        _context.Filmes.Add(filme);
        _context.SaveChanges();
        // indica que um novo recurso foi criado na API e informa a localização do novo recurso
        return CreatedAtAction(nameof(RecuperaPorId),
            new { id = filme.Id },
            filme);

    }

    /// <summary>
    /// Retrieves a collection of films with pagination applied.
    /// </summary>
    /// <remarks>Use the <paramref name="skip"/> and <paramref name="take"/> parameters to implement paging in
    /// client applications. This method is intended for scenarios where large film datasets need to be browsed
    /// efficiently.</remarks>
    /// <param name="skip">The number of films to skip before starting to return results. Must be zero or greater.</param>
    /// <param name="take">The maximum number of films to return in the result set. Must be greater than zero.</param>
    /// <returns>An enumerable collection of film data transfer objects representing the requested page of films. The collection
    /// will be empty if no films are available for the specified range.</returns>
    [HttpGet]
    public IEnumerable<ReadFilmeDto> ListarFilmes( [FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List< ReadFilmeDto >>( _context.Filmes.Skip(skip).Take(take));
    }

    /// <summary>
    /// Retrieves a film by its unique identifier.
    /// </summary>
    /// <remarks>Returns an HTTP 200 response with the film details if the film exists, or an HTTP 404
    /// response if no film with the specified identifier is found.</remarks>
    /// <param name="id">The unique identifier of the film to retrieve.</param>
    /// <returns>An <see cref="IActionResult"/> containing the film data if found; otherwise, a NotFound result.</returns>

    [HttpGet("{id}")]
    public IActionResult RecuperaPorId(int id )
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme is null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);

    }

    /// <summary>
    /// Applies a partial update to an existing film resource using a JSON Patch document.
    /// </summary>
    /// <remarks>This method validates the patched film model before applying changes. Only the fields
    /// specified in the patch document are updated. The request will fail if the patch results in an invalid
    /// state.</remarks>
    /// <param name="id">The unique identifier of the film to update.</param>
    /// <param name="patch">A JSON Patch document specifying the changes to apply to the film. Cannot be null.</param>
    /// <returns>An HTTP 204 No Content response if the update is successful; an HTTP 404 Not Found response if the film does not
    /// exist; or an HTTP 400 Validation Problem response if the patch results in an invalid model state.</returns>
    [HttpPatch("{id}")]
    public IActionResult AtualizarFilme (int id,JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme is null) return NotFound();
        var filmeAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

        patch.ApplyTo(filmeAtualizar, ModelState);// valida o modelo
        if (!TryValidateModel(filmeAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeAtualizar, filme); //( origem, destino )
        _context.SaveChanges();

        return NoContent();
    }


    /// <summary>
    /// Deletes the film with the specified identifier from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the film to delete.</param>
    /// <returns>An HTTP 204 No Content response if the film was successfully deleted; otherwise, an HTTP 404 Not Found response
    /// if no film with the specified identifier exists.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeletarFilme ( int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme is null) return NotFound();
        _context.Filmes.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}
