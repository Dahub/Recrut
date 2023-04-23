namespace ReCrut.Test.Commun;

using ReCrut.Domain.Abstractions;

public class FakeDateTimeProvider : IDateTimeProvider
{
    private readonly DateTimeOffset _dateTimeOffset;

    public FakeDateTimeProvider(DateTimeOffset dateTimeOffset)
        => _dateTimeOffset = dateTimeOffset;

    public DateTimeOffset Now => _dateTimeOffset;
}