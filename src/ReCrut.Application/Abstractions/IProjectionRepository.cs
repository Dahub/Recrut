using ReCrut.Domain.Abstractions;

namespace ReCrut.Application.Abstractions;

public interface IProjectionRepository<TProjection> where TProjection : Projection
{
    TProjection? GetById(Guid id);
    
    void Upsert(TProjection projection);

    IEnumerable<TProjection> Get(Func<TProjection, bool> predicat);
}