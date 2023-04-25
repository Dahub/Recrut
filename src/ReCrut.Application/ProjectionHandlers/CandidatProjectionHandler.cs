using ReCrut.Application.Abstractions;
using ReCrut.Domain.Abstractions;
using ReCrut.Domain.Candidat.Events;

namespace ReCrut.Application.ProjectionHandlers;

public class CandidatProjectionHandler : IProjectionHandler
{
    private readonly IProjectionRepository _projectionRepository;

    public CandidatProjectionHandler(IProjectionRepository projectionRepository) 
        => _projectionRepository = projectionRepository;

    public bool CanHandle(Event @event) => @event is CandidatCreeEvent;

    public void Handle(Event @event) => throw new NotImplementedException();
}
