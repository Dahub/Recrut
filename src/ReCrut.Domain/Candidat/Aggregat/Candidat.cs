using ReCrut.Domain.Abstractions;
using ReCrut.Domain.Candidat.Commands;
using ReCrut.Domain.Candidat.Events;
using ReCrut.Domain.Exceptions;

namespace ReCrut.Domain.Candidat.Aggregat;

public static class Candidat
{
    public static (Event, CandidatState) Creer(
        this CandidatState state,
        CreerCandidatCommand command,
        IDateTimeProvider dateTimeProvider)
    {        
        if(command.CandidatStatus == CandidatStatus.Supprime)
        {
            throw new BusinessException("Impossible de créer un candidat à l'état supprimé");
        }

        var @event = new CandidatCreeEvent(
            command.AggregateId,
            1,
            dateTimeProvider.Now,
            nameof(CandidatState),
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