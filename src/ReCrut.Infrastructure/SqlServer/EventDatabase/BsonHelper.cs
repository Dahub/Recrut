using System.Text.Json;
using ReCrut.Domain.Abstractions;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Recrut.Infrastructure.Test")]
namespace ReCrut.Infrastructure.SqlServer.EventDatabase;

internal static class BsonHelper
{
    public static byte[] ToBson<T>(T obj) where T : notnull, Event
    {
        using var ms = new MemoryStream();
        using var writer = new Utf8JsonWriter(ms);
        JsonSerializer.Serialize(writer, obj);
        return ms.ToArray();
    }

    public static T FromBson<T>(byte[] objBytes) where T : notnull, Event => 
        JsonSerializer.Deserialize<T>(objBytes) 
        ?? throw new ArgumentException($"Deserialization vers {nameof(T)} impossible");

    public static Event FromBson(Type eventType, byte[] objBytes) => 
        (JsonSerializer.Deserialize(objBytes, eventType) as Event) 
        ?? throw new ArgumentException($"Deserialization vers {eventType.Name} impossible");
}
