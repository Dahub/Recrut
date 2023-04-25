using ReCrut.Domain.Abstractions;

namespace ReCrut.Application.Abstractions;

public interface IProjectionHandler
{
    bool CanHandle(Event @event);

    void Handle(Event @event);
}
