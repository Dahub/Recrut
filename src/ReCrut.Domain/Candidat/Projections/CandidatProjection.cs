using ReCrut.Domain.Abstractions;
using ReCrut.Domain.Candidat.Aggregat;
using ReCrut.Domain.Candidat.Events;

namespace ReCrut.Domain.Candidat.Projections;

public record CandidatProjection : Projection
{
    public string Nom { get; init; } = string.Empty;

    public string Prenom { get; init; } = string.Empty;

    public string Trigramme { get; init; } = string.Empty;

    public DateOnly DatePriseContact { get; init; } = DateOnly.MinValue;

    public string CandidatStatus { get; init; } = String.Empty;

    public override CandidatProjection With(Event @event) =>
        @event switch
        {
            CandidatCreeEvent candidatCree => this with {
                Id = candidatCree.AggregateId,
                CandidatStatus = ConvertToNiceWording(candidatCree.CandidatStatus),
                DatePriseContact = candidatCree.DatePriseContact,
                Nom = candidatCree.Nom,
                Prenom = candidatCree.Prenom,
                Trigramme = candidatCree.Trigramme
            },
            _ => this
        };

    private static string ConvertToNiceWording(CandidatStatus candidatStatus) =>
        candidatStatus switch
        {
            Aggregat.CandidatStatus.CommercialAContacter => "Commercial à contacter",
            Aggregat.CandidatStatus.CandidatAContacter => "Candidat à contacter",
            Aggregat.CandidatStatus.EntretienAPlanifier => "Entretien à planifier",
            Aggregat.CandidatStatus.ReponseOkADonner => "Réponse OK à donner",
            Aggregat.CandidatStatus.ReponsekoADonner => "Réponse KO à donner",
            Aggregat.CandidatStatus.Supprime => "Supprimé",
            _ => "Inconnu"
        };
}
