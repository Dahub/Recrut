using ReCrut.Domain.Abstraction;
using ReCrut.Domain.Candidat.Aggregat;

namespace ReCrut.Domain.Candidat.Commands;

public record CreerCandidatCommand(
    Guid AggregateId,
    string Nom, 
    string Prenom, 
    string Trigramme, 
    DateOnly DatePriseContact,
    CandidatStatus CandidatStatus) : Command(AggregateId);