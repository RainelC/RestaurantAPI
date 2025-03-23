using System.Text.Json.Serialization;

namespace RestaurantAPI.Core.Application.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TableStatus
    {
        Disponible,
        EnProceso,
        Atendida
    }
}
