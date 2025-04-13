using System.Text.Json.Serialization;
using Domain.Entities.Enums;

namespace Api.Requests.ShowSchedules;

public class CreateShowScheduleRequest
{
    public long MovieId { get; set; }
    public long TheaterId { get; set; }
    public DateTimeOffset From { get; set; }
    public DateTimeOffset To { get; set; }
    public ShowScheduleStatus Status { get; set; }
}