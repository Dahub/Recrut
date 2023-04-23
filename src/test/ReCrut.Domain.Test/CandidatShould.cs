namespace ReCrut.Domain.Test;

using ReCrut.Domain.Abstractions;

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
        var aggregateName = nameof(CandidatState);

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
        eventAndState.state.Should().NotBeNull();

        var expectedEvent = new CandidatCreeEvent(
            aggregateId,
            1,
            dateTimeProvider.Now,
            aggregateName,
            nom,
            prenom,
            trigramme,
            datePriseContact,
            candidatStatus);

        eventAndState.@event.Should().Be(expectedEvent);

        var expectedState = new CandidatState()
        {
            AggregateId = aggregateId,
            AggregateVersion = 1,
            CandidatStatus = candidatStatus,
            DatePriseContact = datePriseContact,
            Nom = nom,
            Prenom = prenom,
            Trigramme = trigramme
        };

        eventAndState.state.Should().Be(expectedState);
    }
}