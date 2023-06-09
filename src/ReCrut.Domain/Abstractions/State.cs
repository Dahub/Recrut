namespace ReCrut.Domain.Abstractions;
public abstract record State<TState>(
    Guid AggregateId,
    int AggregateVersion) where TState : State<TState>, new()
{
    public abstract TState With(Event @event);

    public static TState From(IEnumerable<Event> events) =>
        events.Aggregate(
            seed: Activator.CreateInstance<TState>(),
            func: (state, @event) => state.With(@event));
}