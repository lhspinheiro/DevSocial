using DevSocial.Communication.Response;
using DevSocial.Exception;
using DevSocial.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DevSocial.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is DevSocialException)
        {
            HandleException(context);
        }
        else
        {
           // ThrowUnkowError(context);
        }
    }

    private void HandleException(ExceptionContext context)
    {
        var devSocialException = (DevSocialException)context.Exception;
        var errorResponse = new ResponseErrorJson(devSocialException.GetErros());

        context.HttpContext.Response.StatusCode = devSocialException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }

    private void ThrowUnkowError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(ResourcesErrorMessages.UNKNOW_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    } 
}
