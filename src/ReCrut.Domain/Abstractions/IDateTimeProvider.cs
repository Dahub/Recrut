namespace ReCrut.Domain.Abstractions;

public interface IDateTimeProvider
{
    DateTimeOffset Now { get; }
}