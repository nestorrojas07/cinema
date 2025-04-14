using System.Text.Json.Serialization;
using Domain.Entities.Enums;

namespace Api.Requests.ShowSchedules;

public class CreateShowScheduleRequest
{
    public long MovieListId { get; set; }
    public long HallId { get; set; }
    public DateTimeOffset StartAt { get; set; }
    public DateTimeOffset EndAt { get; set; }
    public ShowScheduleStatus Status { get; set; }
}