using ReCrut.Domain.Candidat.Projections;

namespace ReCrut.Domain.Abstractions;

public abstract record Projection
{
    public Guid Id { get; init; } = Guid.Empty;

    public abstract CandidatProjection With(Event @event);
}
