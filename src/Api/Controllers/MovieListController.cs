using Api.Mappers;
using Api.Requests.MovieLists;
using Application.Services;
using Domain.Entities;
using Domain.ObjectValues.MovieLists;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieListController : ControllerBase
{
    private readonly MovieListService _hallService;

    public MovieListController(MovieListService hallService)
    {
        _hallService = hallService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieList>>> GetAll([FromQuery] MovieListSearchRequest request, CancellationToken token = default)
    {
        var movies = await _hallService.GetAllAsync(request.ToMovieListSearch(), token);
        return Ok(movies);
    }
    

    // GET: api/hall/5
    [HttpGet("{id}")]
    public async Task<ActionResult<MovieList>> Get(int id)
    {
        var movie = await _hallService.GetByIdAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    // POST: api/hall
    [HttpPost]
    public async Task<ActionResult<MovieList>> Post([FromBody] CreateMovieListRequest request)
    {
        if (request == null)
        {
            return BadRequest("MovieList cannot be null.");
        }

        var movie = await _hallService.CreateAsync(request.ToMovieListCreate());

        return Ok(movie);
    }

    
    // PUT: api/hall/5
    [HttpPut("{id}")]
    public async Task<ActionResult<MovieList>> Put(long id, [FromBody] UpdateMovieListRequest movie)
    {
        try
        {
            return Ok(await _hallService.UpdateAsync(id, movie.ToMovieListValue()));
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}