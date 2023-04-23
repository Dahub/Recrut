using ReCrut.Domain.Abstractions;

namespace ReCrut.Infrastructure;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}
