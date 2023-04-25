using ReCrut.Application.Abstractions;
using ReCrut.Domain.Abstractions;
using ReCrut.Domain.Candidat.Events;
using ReCrut.Domain.Candidat.Projections;

namespace ReCrut.Application.ProjectionHandlers;

public class CandidatProjectionHandler : IProjectionHandler
{
    private readonly IProjectionRepository _projectionRepository;

    public CandidatProjectionHandler(IProjectionRepository projectionRepository) 
        => _projectionRepository = projectionRepository;

    public bool CanHandle(Event @event) => @event is CandidatCreeEvent;

    public void Handle(Event @event)
    {
        var projection = _projectionRepository.GetById<CandidatProjection>(@event.AggregateId) ?? new CandidatProjection();
        projection = projection.With(@event);
        _projectionRepository.Upsert(projection);
    }
}
