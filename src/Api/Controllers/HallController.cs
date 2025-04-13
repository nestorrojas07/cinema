using Api.Mappers;
using Api.Requests.Hall;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HallController : ControllerBase
{
    private readonly HallService _hallService;

    public HallController(HallService hallService)
    {
        _hallService = hallService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Hall>>> GetAll()
    {
        var movies = await _hallService.GetAllAsync();
        return Ok(movies);
    }
    

    // GET: api/hall/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Hall>> Get(int id)
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
    public async Task<ActionResult<Hall>> Post([FromBody] CreateHallRequest request)
    {
        if (request == null)
        {
            return BadRequest("Hall cannot be null.");
        }

        var movie = await _hallService.CreateAsync(request.ToHallCreate());

        return Ok(movie);
    }

    
    // PUT: api/hall/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Hall>> Put(long id, [FromBody] UpdateHallRequest movie)
    {
        try
        {
            return Ok(await _hallService.UpdateAsync(id, movie.ToHallValue()));
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}