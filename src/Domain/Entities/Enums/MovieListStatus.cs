using System.Text.Json.Serialization;

namespace Domain.Entities.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MovieListStatus
{
    NoListed = 0,
    Scheduled = 1,
    Soon = 2,
    Finished = 3,
}