using ReCrut.Domain.Abstractions;

namespace ReCrut.Application.Abstractions;

public interface IProjectionRepository
{
    Projection? GetById<TProjection>(Guid id) where TProjection : Projection;
    
    void Upsert(Projection projection);
}