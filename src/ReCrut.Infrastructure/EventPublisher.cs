using ReCrut.Application.Abstractions;
using ReCrut.Application.ProjectionHandlers;
using ReCrut.Domain.Abstractions;

namespace ReCrut.Infrastructure;

public class EventPublisher : IEventPublisher
{
    private readonly IList<IProjectionHandler> _projectionHandlers = new List<IProjectionHandler>();

    public EventPublisher(
        CandidatProjectionHandler candidatProjectionHandler)
    {
        _projectionHandlers.Add(candidatProjectionHandler);
    }

    public void Publish(Event @event)
    {
        foreach (var handler in _projectionHandlers.Where(h => h.CanHandle(@event)))
        {
            handler.Handle(@event);
        }
    }
}
