using ReCrut.Domain.Abstractions;

namespace ReCrut.Application.Abstractions;

public interface IEventPublisher
{
    void Publish(Event @event);
}
