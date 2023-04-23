using ReCrut.Application.Abstractions;
using ReCrut.Domain.Abstractions;

namespace ReCrut.Test.Commun;

public class FakeEventRepository : IEventRepository
{
    public List<Event> SavedEvents { get; set; } = new();

    public IOrderedEnumerable<Event> GetAggregateEvents(Guid aggregateId) =>
        SavedEvents.Where(e => e.AggregateId.Equals(aggregateId)).OrderBy(e => e.AggregateVersion);

    public void Save(Event @event) => SavedEvents.Add(@event);
}
