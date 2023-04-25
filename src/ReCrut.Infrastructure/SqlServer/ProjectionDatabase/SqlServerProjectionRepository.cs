using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReCrut.Application.Abstractions;
using ReCrut.Domain.Abstractions;
using ReCrut.Domain.Candidat.Projections;

namespace ReCrut.Infrastructure.SqlServer.ProjectionDatabase;

public class SqlServerProjectionRepository : IProjectionRepository
{
    private readonly ILogger<SqlServerProjectionRepository> _logger;
    private readonly ProjectionDbContext _projectionDbContext;

    public SqlServerProjectionRepository(
        ILogger<SqlServerProjectionRepository> logger,
        ProjectionDbContext projectionDbContext)
    {
        _logger = logger;
        _projectionDbContext = projectionDbContext;
    }

    public Projection? GetById<TProjection>(Guid id) where TProjection : Projection
    {
        _logger.LogInformation("Lecture d'une projection de type {type}, id {id}", typeof(TProjection), id);

        if (typeof(TProjection) == typeof(CandidatProjection))
        {
            return _projectionDbContext.Candidats.Find(id)?.ToProjection();
        }

        throw new Exception("Impossible trouver la projection, type inconnu");
    }
    
    public void Upsert(Projection projection)
    {
        _logger.LogInformation("Upsert d'une projection de type {type}, id {id}", projection.GetType(), projection.Id);

        if (projection is CandidatProjection candidatProjection)
        {
            var efEntity = candidatProjection.ToEfEntity();
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
        else
        {
            throw new Exception("Impossible de sauvergarder la projection, type inconnu");
        }
    }
}
