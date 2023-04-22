using ReCrut.Domain.Abstraction;
using ReCrut.Domain.Candidat.Commands;
using ReCrut.Domain.Candidat.Events;

namespace ReCrut.Domain.Candidat.Aggregat;

public static class Candidat
{
    public static (Event, State<CandidatState>) Creer(
        this CandidatState state,
        CreerCandidatCommand command,
        IDateTimeProvider dateTimeProvider)
    {        
        var @event = new CandidatCreeEvent(
            command.AggregateId,
            1,
            dateTimeProvider.Now,
            command.Nom,
            command.Prenom,
            command.Trigramme,
            command.DatePriseContact,
            command.CandidatStatus
        );

        state = state.With(@event);

        return (@event, state);
    }
}