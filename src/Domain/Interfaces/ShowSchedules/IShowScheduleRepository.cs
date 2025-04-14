using Domain.Entities;
using Domain.Interfaces.Core;
using Domain.ObjectValues.ShowSchedules;

namespace Domain.Interfaces.ShowSchedules;

public interface IShowScheduleRepository : ICreate<ShowSchedule>, IUpdate<ShowScheduleUpdateValue, long, ShowSchedule>, IRead<ShowSchedule>
{
    Task<IEnumerable<ShowSchedule>> GetAllAsync(CancellationToken token = default);
    Task<IEnumerable<ShowSchedule>> GetAllAsync(ShowScheduleSearch filter,CancellationToken token = default);

    Task IncrementSeatsStaticsticsAsyc(long showId, int seatsAvailable, int seatSold,
        CancellationToken token = default);
}