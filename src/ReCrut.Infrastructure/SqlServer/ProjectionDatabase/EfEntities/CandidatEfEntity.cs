namespace ReCrut.Infrastructure.SqlServer.ProjectionDatabase.EfEntities;

internal class CandidatEfEntity
{
    public Guid Id { get; set; }

    public string Nom { get; set; } = string.Empty;

    public string Prenom { get; set; } = string.Empty;

    public string Trigramme { get; set; } = string.Empty;

    public DateTime DatePriseContact { get; set; } = DateTime.MinValue;

    public string CandidatStatus { get; set; } = String.Empty;
}
