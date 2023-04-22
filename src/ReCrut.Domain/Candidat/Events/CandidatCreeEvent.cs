using ReCrut.Domain.Abstraction;
using ReCrut.Domain.Candidat.Aggregat;

namespace ReCrut.Domain.Candidat.Events;

public record CandidatCreeEvent(
    Guid AggregateId,
    int AggregateVersion,
    DateTimeOffset EventDate,
    string Nom,
    string Prenom,
    string Trigramme,
    DateOnly DatePriseContact,
    CandidatStatus CandidatStatus) :
Event(
    AggregateId,
    AggregateVersion,
    EventDate);