using System.Text.Json.Serialization;

namespace Domain.Entities.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ReservationStatus
{
    NoAssigned = 0,
    Reserved = 1,
    Payed = 2,
}