using ReCrut.Application.Abstractions;
using ReCrut.Domain.Abstractions;

namespace ReCrut.Test.Commun;

public class FakeEventPublisher : IEventPublisher
{
    public List<Event> PublishedEvents { get; set; } = new();

    public void Publish(Event @event) => PublishedEvents.Add(@event);
}
