using Api.Mappers;
using Api.Requests.ShowSchedules;
using Application.Services;
using Domain.Entities;
using Domain.ObjectValues.ShowSchedules;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShowScheduleController : ControllerBase
{
    private readonly ShowScheduleService _hallService;

    public ShowScheduleController(ShowScheduleService hallService)
    {
        _hallService = hallService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShowSchedule>>> GetAll([FromQuery] ShowScheduleSearchRequest request, CancellationToken token = default)
    {
        var movies = await _hallService.GetAllAsync(request.ToShowScheduleSearch(), token);
        return Ok(movies);
    }
    

    // GET: api/hall/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ShowSchedule>> Get(int id)
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
    public async Task<ActionResult<ShowSchedule>> Post([FromBody] CreateShowScheduleRequest request)
    {
        if (request == null)
        {
            return BadRequest("ShowSchedule cannot be null.");
        }

        var movie = await _hallService.CreateAsync(request.ToShowScheduleCreate());

        return Ok(movie);
    }

    
    // PUT: api/hall/5
    [HttpPut("{id}")]
    public async Task<ActionResult<ShowSchedule>> Put(long id, [FromBody] UpdateShowScheduleRequest movie)
    {
        try
        {
            return Ok(await _hallService.UpdateAsync(id, movie.ToShowScheduleValue()));
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}