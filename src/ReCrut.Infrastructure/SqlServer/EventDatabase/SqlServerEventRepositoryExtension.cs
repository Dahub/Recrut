using ReCrut.Domain.Abstractions;
using System.Reflection;

namespace ReCrut.Infrastructure.SqlServer.EventDatabase;

internal static class SqlServerEventRepositoryExtension
{
    public static EventEfEntity ToEfEntity<T>(this T @event) where T : notnull, Event =>
            new()
            {
                AggregateId = @event.AggregateId,
                AggregateName = @event.AggregateName,
                EventName = @event.EventName,
                Id = Guid.NewGuid(),
                TimeStamp = @event.EventDate.DateTime,
                Version = @event.AggregateVersion,
                EventDatas = BsonHelper.ToBson(@event)
            };

    public static Event ToEvent(this EventEfEntity eventEfEntity)
    {
        var eventType = Assembly.GetAssembly(typeof(Event))?.GetType(eventEfEntity.EventName);
        return eventType == null
            ? throw new ArgumentException($"Erreur lors de la récupération du type de l'event {eventEfEntity.EventName}")
            : BsonHelper.FromBson(eventType, eventEfEntity.EventDatas);
    }

    public static IEnumerable<Event> ToEvent(this IEnumerable<EventEfEntity> eventEfEntities) =>
        eventEfEntities.Select(e => e.ToEvent());
}
