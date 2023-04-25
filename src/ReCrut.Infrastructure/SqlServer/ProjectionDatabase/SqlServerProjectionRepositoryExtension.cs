using ReCrut.Domain.Candidat.Projections;
using ReCrut.Infrastructure.SqlServer.ProjectionDatabase.EfEntities;

namespace ReCrut.Infrastructure.SqlServer.ProjectionDatabase;

internal static class SqlServerProjectionRepositoryExtension
{
    public static CandidatEfEntity ToEfEntity(this CandidatProjection projection)
         => new()
        {
            Id = projection.Id,
            CandidatStatus = projection.CandidatStatus,
            DatePriseContact = projection.DatePriseContact.ToDateTime(TimeOnly.MinValue),
            Nom = projection.Nom,
            Prenom = projection.Prenom,
            Trigramme = projection.Trigramme
        };

    public static CandidatProjection ToProjection(this CandidatEfEntity entity)
      => new CandidatProjection()
      {
          Id = entity.Id,
          CandidatStatus = entity.CandidatStatus,
          DatePriseContact = DateOnly.FromDateTime(entity.DatePriseContact),
          Nom = entity.Nom,
          Prenom = entity.Prenom,
          Trigramme = entity.Trigramme
      };
}
