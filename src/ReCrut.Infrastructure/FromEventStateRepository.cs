using ReCrut.Application.Abstractions;
using ReCrut.Domain.Abstractions;

namespace ReCrut.Infrastructure;

public class FromEventStateRepository : IStateRepository
{
    private readonly IEventRepository _eventRepository;

    public FromEventStateRepository(IEventRepository eventRepository) => _eventRepository = eventRepository;

    public TState GetByAggregateId<TState>(Guid aggregateId) where TState : State<TState>, new()
    {
        var events = _eventRepository.GetAggregateEvents(aggregateId);
        return State<TState>.From(events);
    }
}
