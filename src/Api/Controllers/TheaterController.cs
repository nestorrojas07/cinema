using Api.Mappers;
using Api.Requests.Theater;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TheaterController : ControllerBase
{
    private readonly TheaterService _theaterService;

    public TheaterController(TheaterService theaterService)
    {
        _theaterService = theaterService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Theater>>> GetAll()
    {
        var movies = await _theaterService.GetAllAsync();
        return Ok(movies);
    }
    

    // GET: api/theater/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Theater>> Get(int id)
    {
        var movie = await _theaterService.GetByIdAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    // POST: api/theater
    [HttpPost]
    public async Task<ActionResult<Theater>> Post([FromBody] CreateTheaterRequest request)
    {
        if (request == null)
        {
            return BadRequest("Theater cannot be null.");
        }

        var movie = await _theaterService.CreateAsync(request.ToTheaterCreate());

        return Ok(movie);
    }

    
    // PUT: api/theater/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Theater>> Put(long id, [FromBody] UpdateTheaterRequest movie)
    {
        try
        {
            return Ok(await _theaterService.UpdateAsync(id, movie.ToTheaterValue()));
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}