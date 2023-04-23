using ReCrut.Domain.Abstractions;
using ReCrut.Domain.Candidat.Events;

namespace ReCrut.Domain.Candidat.Aggregat;

public record CandidatState : State<CandidatState>
{
    public CandidatState() : base(Guid.Empty, 0)
    {
    }

    public string Nom { get; init; } = string.Empty;

    public string Prenom { get; init; } = string.Empty;

    public string Trigramme { get; init; } = string.Empty;

    public DateOnly DatePriseContact { get; init; } = DateOnly.MinValue;

    public CandidatStatus CandidatStatus { get; init; } = CandidatStatus.CommercialAContacter;

    public override CandidatState With(Event @event) =>
        @event switch
        {
            CandidatCreeEvent evt => this with {AggregateId = evt.AggregateId, AggregateVersion = evt.AggregateVersion, CandidatStatus = evt.CandidatStatus, DatePriseContact = evt.DatePriseContact, Nom = evt.Nom, Prenom = evt.Prenom, Trigramme = evt.Trigramme},
            _ => this
        };
}
