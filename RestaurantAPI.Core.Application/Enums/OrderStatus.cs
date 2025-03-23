using System.Text.Json.Serialization;

namespace RestaurantAPI.Core.Application.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus
    {
        EnProceso,
        Completada
    }
}
