using Api.Mappers;
using Api.Requests.Movie;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly MovieService _movieService;

    public MovieController(MovieService movieService)
    {
        _movieService = movieService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetAll()
    {
        var movies = await _movieService.GetAllAsync();
        return Ok(movies);
    }
    

    // GET: api/movie/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> Get(int id)
    {
        var movie = await _movieService.GetByIdAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    // POST: api/movie
    [HttpPost]
    public async Task<ActionResult<Movie>> Post([FromBody] CreateMovieRequest request)
    {
        if (request == null)
        {
            return BadRequest("Movie cannot be null.");
        }

        var movie = await _movieService.CreateAsync(request.ToMovie());

        return Ok(movie);
    }

    
    // PUT: api/movie/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Movie>> Put(long id, [FromBody] UpdateMovieRequest movie)
    {
        try
        {
            return Ok(await _movieService.UpdateAsync(id, movie.ToMovieValue()));
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}