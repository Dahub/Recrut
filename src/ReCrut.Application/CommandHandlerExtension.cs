using ReCrut.Application.Abstractions;
using ReCrut.Domain.Abstractions;

namespace ReCrut.Application;

public static class CommandHandlerExtension
{
    public static Event Save<TState>(this (Event @event, TState state) eventAndState, IEventRepository eventRepository)
    {
        eventRepository.Save(eventAndState.@event);
        return eventAndState.@event;
    }

    public static HandleResult Publish(this Event @event, IEventPublisher eventPublisher)
    {
        eventPublisher.Publish(@event);
        return HandleResult.Ok();
    }
}
