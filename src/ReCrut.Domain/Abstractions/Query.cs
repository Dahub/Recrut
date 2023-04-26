namespace ReCrut.Domain.Abstractions;

public abstract record Query<TProjection> where TProjection: Projection
{
    public abstract Func<TProjection, bool> Predicate { get; }
}
