namespace ReCrut.Domain.Test;

using ReCrut.Domain.Abstractions;
using ReCrut.Domain.Exceptions;

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
        (Event @event, State<CandidatState> state) = candidatState.Creer(creerCandidatCommand, dateTimeProvider);

        // Then
        @event.Should().NotBeNull();
        state.Should().NotBeNull();

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

        @event.Should().Be(expectedEvent);

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

        state.Should().Be(expectedState);
    }

    [Fact]
    public void ThrowBusinessExceptionWhenCreatedWithCandidatStatusSupprime()
    {
        // Given
        var aggregateId = Guid.NewGuid();
        var nom = Guid.NewGuid().ToString();
        var prenom = Guid.NewGuid().ToString();
        var trigramme = Guid.NewGuid().ToString();
        var candidatStatus = CandidatStatus.Supprime;
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
        var act = () => candidatState.Creer(creerCandidatCommand, dateTimeProvider);

        //Then
        act.Should().Throw<BusinessException>();
    }
}