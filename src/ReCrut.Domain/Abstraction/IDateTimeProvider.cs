namespace ReCrut.Domain.Abstraction;

public interface IDateTimeProvider
{
    DateTimeOffset Now { get; }
}