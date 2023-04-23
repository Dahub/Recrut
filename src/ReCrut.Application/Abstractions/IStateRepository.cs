using ReCrut.Domain.Abstractions;

namespace ReCrut.Application.Abstractions;

public interface IStateRepository
{
    TState GetByAggregateId<TState>(Guid aggregateId) where TState : State<TState>, new();
}
