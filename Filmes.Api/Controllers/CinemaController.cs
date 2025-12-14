using AutoMapper;
using Filmes.Api.Data;
using Filmes.Api.Data.DTos;
using Filmes.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CinemaController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public CinemaController ( FilmeContext context , IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds a new cinema to the database.
        /// </summary>
        /// <param name="cinemaDto">The data transfer object containing the details of the cinema to add. Must not be null.</param>
        /// <returns>A 201 Created response with a location header pointing to the newly created cinema and the submitted cinema
        /// data in the response body.</returns>
        [HttpPost]
        public IActionResult AdicionaCinema ( [FromBody] CreateCinemaDto cinemaDto )
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCinemasPorId) , new { Id = cinema.Id } , cinemaDto);
        }

        /// <summary>
        /// Retrieves a collection of cinemas.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="ReadCinemaDto"/> objects representing all cinemas. The collection is
        /// empty if no cinemas are found.</returns>
        [HttpGet]
        public IEnumerable<ReadCinemaDto> RecuperaCinemas ( [FromQuery] int? enderecoId = null )
        {
            var query = _context.Cinemas.AsQueryable();
            if (enderecoId is not null)
            {
                query = query.Where(Cinema => Cinema.EnderecoId == enderecoId);
            }
            return _mapper.Map<List<ReadCinemaDto>>(query.ToList());
        }


        /// <summary>
        /// Retrieves the details of a cinema with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the cinema to retrieve.</param>
        /// <returns>An <see cref="OkObjectResult"/> containing the cinema details if found; otherwise, a <see
        /// cref="NotFoundResult"/> if no cinema with the specified identifier exists.</returns>
        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId ( int id )
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return Ok(cinemaDto);
            }
            return NotFound();
        }


        /// <summary>
        /// Updates the details of an existing cinema with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the cinema to update.</param>
        /// <param name="cinemaDto">An object containing the updated values for the cinema. All required fields must be provided.</param>
        /// <returns>An IActionResult indicating the result of the operation. Returns NoContent if the update is successful;
        /// NotFound if a cinema with the specified identifier does not exist.</returns>
        [HttpPut("{id}")]
        public IActionResult AtualizaCinema ( int id , [FromBody] UpdateCinemaDto cinemaDto )
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _mapper.Map(cinemaDto , cinema);
            _context.SaveChanges();
            return NoContent();
        }



        /// <summary>
        /// Deletes the cinema with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the cinema to delete.</param>
        /// <returns>An <see cref="NoContentResult"/> if the cinema was successfully deleted; otherwise, a <see
        /// cref="NotFoundResult"/> if no cinema with the specified identifier exists.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeletaCinema ( int id )
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }

    }
}