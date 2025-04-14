using System.Text.Json.Serialization;

namespace Domain.Entities.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ShowScheduleStatus
{
    NoListed = 0,
    Scheduled = 1,
    Finished = 2,
}