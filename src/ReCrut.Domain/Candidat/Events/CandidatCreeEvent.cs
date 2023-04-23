using ReCrut.Domain.Abstractions;
using ReCrut.Domain.Candidat.Aggregat;

namespace ReCrut.Domain.Candidat.Events;

public record CandidatCreeEvent(
    Guid AggregateId,
    int AggregateVersion,
    DateTimeOffset EventDate,
    string AggregateName,
    string Nom,
    string Prenom,
    string Trigramme,
    DateOnly DatePriseContact,
    CandidatStatus CandidatStatus) :
Event(
    AggregateId,
    AggregateVersion,
    EventDate,
    AggregateName);