namespace ReCrut.Domain.Abstractions;

public abstract record Projection
{
    public Guid Id { get; init; } = Guid.Empty;
}
