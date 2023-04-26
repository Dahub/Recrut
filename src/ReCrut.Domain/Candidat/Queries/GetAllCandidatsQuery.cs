using ReCrut.Domain.Abstractions;
using ReCrut.Domain.Candidat.Projections;

namespace ReCrut.Domain.Candidat.Queries;

public record GetAllCandidatsQuery : Query<CandidatProjection>
{
    public override Func<CandidatProjection, bool> Predicate => _ => true;
}
