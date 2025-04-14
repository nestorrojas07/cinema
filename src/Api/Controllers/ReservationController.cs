using Api.Mappers;
using Api.Requests.ShowSchedules;
using Application.Services;
using Domain.Entities;
using Domain.ObjectValues.ShowSchedules;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationController : ControllerBase
{
    private readonly ReservationService _reservationService;

    public ReservationController(ReservationService reservationService)
    {
        _reservationService = reservationService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reservation>>> GetAll([FromQuery] ReservationSearchRequest request, CancellationToken token = default)
    {
        var movies = await _reservationService.GetAllAsync(request.ToReservationSearch(), token);
        return Ok(movies);
    }
    

    // GET: api/hall/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Reservation>> Get(int id)
    {
        var movie = await _reservationService.GetByIdAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    // POST: api/hall
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ReservationSeatRequest request)
    {
        if (request == null)
        {
            return BadRequest("Reservation cannot be null.");
        }

        await _reservationService.ReservationSeatAsync(request.ToReservationSeat());

        return Created();
    }

    
    // PUT: api/hall/5
    [HttpPut("{id}/cancel")]
    public async Task<ActionResult> CancelAsync(long id, CancellationToken token = default)
    {
        await _reservationService.CancelAsync(id, token);
        return Ok();
    }
    
    [HttpPost("{id}/payment")]
    public async Task<ActionResult> Payment([FromBody] ReservationPaymentRequest request)
    {
        if (request == null)
        {
            return BadRequest("Reservation cannot be null.");
        }

        await _reservationService.PaymentAsync(request.ToReservationPayment());

        return Created();
    }
}