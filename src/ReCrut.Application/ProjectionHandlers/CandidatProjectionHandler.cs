using ReCrut.Application.Abstractions;
using ReCrut.Domain.Abstractions;
using ReCrut.Domain.Candidat.Events;
using ReCrut.Domain.Candidat.Projections;

namespace ReCrut.Application.ProjectionHandlers;

public class CandidatProjectionHandler : IProjectionHandler
{
    private readonly IProjectionRepository<CandidatProjection> _projectionRepository;

    public CandidatProjectionHandler(IProjectionRepository<CandidatProjection> projectionRepository) 
        => _projectionRepository = projectionRepository;

    public bool CanHandle(Event @event) => @event is CandidatCreeEvent;

    public void Handle(Event @event)
    {
        var projection = _projectionRepository.GetById(@event.AggregateId) ?? new CandidatProjection();
        projection = projection.With(@event);
        _projectionRepository.Upsert(projection);
    }
}
