using ReCrut.Application.Abstractions;

namespace ReCrut.Api;

public static class HttpExtension
{
    public static IResult ToHttpResponse(this HandleResult handleResult) =>
        handleResult switch
        {
            HandleResultOk _ => Results.Ok(),
            HandleResultError error => Results.BadRequest(error.ErrorMessage),
            HandleResultException exception => Results.Problem(detail: exception.ErrorMessage),
            _ => Results.BadRequest("Handle result non pris en charge")
        };
}
