using Microsoft.EntityFrameworkCore;
using ReCrut.Application.Abstractions;
using ReCrut.Domain.Candidat.Projections;

namespace ReCrut.Infrastructure.SqlServer.ProjectionDatabase.Repositories;

public class SqlServerCandidatRepository : IProjectionRepository<CandidatProjection>
{
    private readonly ProjectionDbContext _projectionDbContext;

    public SqlServerCandidatRepository(ProjectionDbContext projectionDbContext) =>
        _projectionDbContext = projectionDbContext;

    public IEnumerable<CandidatProjection> Get(Func<CandidatProjection, bool> predicate) =>
        _projectionDbContext.Candidats.Select(c => c.ToProjection()).Where(predicate);

    public CandidatProjection? GetById(Guid id) =>
        _projectionDbContext.Candidats.SingleOrDefault(c => c.Id.Equals(id))?.ToProjection();

    public void Upsert(CandidatProjection projection)
    {
        var efEntity = projection.ToEfEntity();

        if (_projectionDbContext.Candidats.Any(c => c.Id.Equals(projection.Id)))
        {
            _projectionDbContext.ChangeTracker.Clear();
            _projectionDbContext.Attach(efEntity);
            _projectionDbContext.Entry(efEntity).State = EntityState.Modified;
            _projectionDbContext.Update(efEntity);
        }
        else
        {
            _projectionDbContext.Add(efEntity);
        }
        _projectionDbContext.SaveChanges();
    }
}
