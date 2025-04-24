using LivroDeReceitas.Communication.Responses;
using LivroDeReceitas.Exceptions;
using LivroDeReceitas.Exceptions.ExecptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace LivroDeReceitas.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is LivroDeReceitasException)
            HandlerProjectException(context);
        else
            ThrowUnkownException(context);
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

    private void ThrowUnkownException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessagesExceptions.UNKOWN_ERROR));
    }
}