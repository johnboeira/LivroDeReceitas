using LivroDeReceitas.Communication.Responses;
using LivroDeReceitas.Exceptions.ExecptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace LivroDeReceitas.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is LivroDeReceitasException)
        {
            HandlerProjectException(context);
        }
        else
        {

        }
    }

    private void HandlerProjectException(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValidationException)
        {
            var exception = context.Exception as ErrorOnValidationException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.ErrorsMessages));
        }
    }
}
