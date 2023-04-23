using Microsoft.Extensions.Logging;
using ReCrut.Application.Abstractions;
using ReCrut.Domain.Abstractions;
using ReCrut.Domain.Candidat.Aggregat;
using ReCrut.Domain.Candidat.Commands;

namespace ReCrut.Application;

public class CommandHandler
{
    private readonly ILogger<CommandHandler> _logger;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IStateRepository _stateRepository;
    private readonly IEventRepository _eventRepository;
    private readonly IEventPublisher _eventPublisher;

    public CommandHandler(
        ILogger<CommandHandler> logger,
        IDateTimeProvider dateTimeProvider,
        IStateRepository stateRepository,
        IEventRepository eventRepository,
        IEventPublisher eventPublisher)
    {
        _logger = logger;
        _dateTimeProvider = dateTimeProvider;
        _stateRepository = stateRepository;
        _eventRepository = eventRepository;
        _eventPublisher = eventPublisher;
    }

    public HandleResult Handle(Command command) =>
        command switch
        {
            CreerCandidatCommand creerCandidatCommand => Handle<CandidatState>(command.AggregateId, (s) => s.Creer(creerCandidatCommand, _dateTimeProvider)),
            _ => HandleResult.Error($"Type de command {nameof(command)} non pris en charge")
        };

    private HandleResult Handle<TState>(Guid aggregateId, Func<TState, (Event @event, TState state)> func) where TState : State<TState>, new()
    {
        try
        {
            _logger.LogInformation($"Handle d'une commande pour l'aggregat {aggregateId}");

            var state = GetState<TState>(aggregateId);
            func(state).Save(_eventRepository).Publish(_eventPublisher);

            return HandleResult.Ok();
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, ex.Message);

            return HandleResult.Exception(ex, ex.Message);
        }
    }

    private TState GetState<TState>(Guid aggregateId) where TState : State<TState>, new() => _stateRepository.GetByAggregateId<TState>(aggregateId);
}
