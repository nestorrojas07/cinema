using Application.Mappers;
using Application.Utils;
using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Exceptions;
using Domain.Interfaces.MovieLists;
using Domain.Interfaces.Movies;
using Domain.Interfaces.ShowSchedules;
using Domain.Interfaces.Theaters;
using Domain.ObjectValues.ShowSchedules;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class ShowScheduleService
{
    private readonly IShowScheduleRepository _showScheduleRepository;
    private readonly IMovieListRepository _movieListRepository;
    private readonly IMovieRepository _movieRepository;
    private readonly IHallRepository _hallRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly ILogger<ShowScheduleService> _logger;

    public ShowScheduleService(IShowScheduleRepository showScheduleRepository, IMovieListRepository movieListRepository,
        IMovieRepository movieRepository, IHallRepository hallRepository, IReservationRepository reservationRepository,
        ILogger<ShowScheduleService> logger)
    {
        _showScheduleRepository = showScheduleRepository;
        _movieListRepository = movieListRepository;
        _movieRepository = movieRepository;
        _hallRepository = hallRepository;
        _reservationRepository = reservationRepository;
        _logger = logger;
    }

    public async Task<ShowSchedule> CreateAsync(ShowScheduleCreate request, CancellationToken token = default)
    {
        MovieList? movieList = await _movieListRepository.GetByIdAsync(request.MovieListId);
        if(movieList == null)
            throw new KeyNotFoundException($"No movie list found with id {request.MovieListId}");

        if (movieList.Status == MovieListStatus.Finished)
            throw new DomainException("Invalid movie list");
        
        Movie movie = await _movieRepository.GetByIdAsync(movieList.MovieId);
        
        if(movie == null)
            throw new KeyNotFoundException($"No movie list found with id {request.MovieListId}");
        if(request.EndAt > request.StartAt.AddMinutes(movie.DurationMinutes + 60))
            throw new DomainException($"Invalid range of time date, Max Interval of {movie.DurationMinutes + 60} minutes");
        Hall hall = await _hallRepository.GetByIdAsync(request.HallId);
        
        
        var show = await _showScheduleRepository.CreateAsync(request.ToShowSchedule(movieList, hall), token);
        await CreateReservationsAsync(show, hall, token);
        return show;
    }

    public async Task<ShowSchedule> UpdateAsync(long id, ShowScheduleUpdateValue entity, CancellationToken token = default)
    {
        return await _showScheduleRepository.UpdateAsync(id, entity, token);
    }

    public async Task<ShowSchedule> GetByIdAsync(long id, CancellationToken token = default)
    {
        return await _showScheduleRepository.GetByIdAsync(id, token);
    }

    public async Task<IEnumerable<ShowSchedule>> GetAllAsync(CancellationToken token = default)
    {
        return await _showScheduleRepository.GetAllAsync(token);
    }

    public async Task<IEnumerable<ShowSchedule>> GetAllAsync(ShowScheduleSearch filter, CancellationToken token = default)
    {
        return await _showScheduleRepository.GetAllAsync(filter, token);
    }

    protected async Task CreateReservationsAsync(ShowSchedule showSchedule, Hall hall, CancellationToken token = default)
    {
        List<Reservation> reservations = new List<Reservation>();
        for (int row = 0; row < hall.Rows; row++)
        {
            for (int col = 0; col < hall.Columns; col++)
            {
                Reservation reservation = CreatePreReservation(showSchedule, hall, row, col);
                reservations.Add(reservation);
            }
        }
        await _reservationRepository.AddAsync(reservations, token);
    }

    protected Reservation CreatePreReservation(ShowSchedule showSchedule, Hall hall, int column, int row)
    {
        return new Reservation()
        {
            MovieId = showSchedule.MovieId,
            HallId = hall.Id,
            Status = ReservationStatus.NoAssigned,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow,
            StartAt = showSchedule.From,
            EndAt = showSchedule.To,
            TheaterId = showSchedule.TheaterId,
            Location = HallLocationUtil.getLocationByColumnAndRow(column, row),
            ShowScheduleId = showSchedule.Id,
        };
    }
}