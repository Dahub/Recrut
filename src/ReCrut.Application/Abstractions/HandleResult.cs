namespace ReCrut.Application.Abstractions;

public abstract record HandleResult()
{
    public static HandleResultOk Ok() => new();

    public static HandleResultError Error(string errorMessage) => new(errorMessage);

    public static HandleResultException Exception(Exception exception, string errorMessage) => new(exception, errorMessage);
}

public record HandleResultOk() : HandleResult;

public record HandleResultError(string ErrorMessage) : HandleResult;

public record HandleResultException(Exception Ex, string ErrorMessage) : HandleResult;