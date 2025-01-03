using System.Text.Json.Serialization;

namespace FuncionarioAPI.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TurnoEnum
    {
        Manhã,
        Tarde,
        Noite
    }
}
