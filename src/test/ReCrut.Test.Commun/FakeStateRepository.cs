using ReCrut.Application.Abstractions;
using ReCrut.Domain.Abstractions;

namespace ReCrut.Test.Commun;

public class FakeStateRepository : IStateRepository
{
    public Dictionary<Guid, object> SavedStates { get; set; } = new();

    public FakeStateRepository()
    {

    }

    public FakeStateRepository WithState<TState>(TState state) where TState : State<TState>, new()
    {
        SavedStates.Add(state.AggregateId, state);
        return this;
    }

    public TState GetByAggregateId<TState>(Guid aggregateId) where TState : State<TState>, new() =>
        SavedStates.ContainsKey(aggregateId) ?
            (TState)SavedStates[aggregateId] :
            Activator.CreateInstance<TState>();
}
