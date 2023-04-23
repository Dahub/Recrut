using ReCrut.Domain.Abstractions;

namespace ReCrut.Application.Abstractions;

public interface IEventRepository
{
    void Save(Event @event);

    IOrderedEnumerable<Event> GetAggregateEvents(Guid aggregateId);
}
