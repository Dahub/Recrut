using ReCrut.Application.Abstractions;
using ReCrut.Domain.Abstractions;
using ReCrut.Domain.Candidat.Projections;
using ReCrut.Domain.Candidat.Queries;

namespace ReCrut.Application;

public class QueryHandler
{
    private readonly IProjectionRepository<CandidatProjection> _candidatProjectionRepository;

    public QueryHandler(IProjectionRepository<CandidatProjection> candidatProjectionRepository)
    {
        _candidatProjectionRepository = candidatProjectionRepository;
    }

    public IEnumerable<Projection> Handle(object query) =>
        query switch
        {
            GetAllCandidatsQuery getAllCandidatsQuery => _candidatProjectionRepository.Get(getAllCandidatsQuery.Predicate),
            _ => throw new ArgumentException("Type de Query non pris en charge")
        };
}
