namespace ReCrut.Domain.Abstraction;

public record Event(
    Guid AggregateId, 
    int AggregateVersion,
    DateTimeOffset EventDate);