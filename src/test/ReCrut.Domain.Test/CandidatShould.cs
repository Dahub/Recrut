namespace ReCrut.Domain.Test;

public class CandidatShould
{
    [Fact]
    public void ReturnCandidatCreeEventWhenCreated()
    {
        // Given
        var aggregateId = Guid.NewGuid();
        var nom = Guid.NewGuid().ToString();
        var prenom = Guid.NewGuid().ToString();
        var trigramme = Guid.NewGuid().ToString();
        var candidatStatus = CandidatStatus.CommercialAContacter;
        var datePriseContact = DateOnly.FromDateTime(DateTime.Now);
        var now = DateTimeOffset.Now;
        var dateTimeProvider = new FakeDateTimeProvider(now);

        var creerCandidatCommand = new CreerCandidatCommand(
            aggregateId,
            nom,
            prenom,
            trigramme,
            datePriseContact,
            candidatStatus
        );

        var events = Enumerable.Empty<Event>();

        var candidatState = CandidatState.From(events);

        // When
        (Event @event, State<CandidatState> state) eventAndState = candidatState.Creer(creerCandidatCommand, dateTimeProvider);    
    
        // Then
        eventAndState.@event.Should().NotBeNull();
    }
}