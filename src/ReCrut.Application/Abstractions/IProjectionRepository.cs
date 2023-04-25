using ReCrut.Domain.Abstractions;

namespace ReCrut.Application.Abstractions;

public interface IProjectionRepository
{
    Projection GetById(Guid id);
    
    void Upsert(Projection projection);
}