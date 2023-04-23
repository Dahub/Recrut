namespace ReCrut.Domain.Abstractions;

public abstract record Event(
    Guid AggregateId,
    int AggregateVersion,
    DateTimeOffset EventDate,
    string AggregateName)
{
    public string EventName => GetType().FullName ?? string.Empty;
}