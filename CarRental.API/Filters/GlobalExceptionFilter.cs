using CarRental.API.DTOs;
using CarRental.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CarRental.API.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var statusCode = HttpStatusCode.InternalServerError;
            var message = exception.Message;

            if (exception.GetType() == typeof(BusinessException))
            {
                statusCode = HttpStatusCode.BadRequest;
            }
            var response = new ResponseDto<bool>(false)
            {
                ErrorMessage = message,
                Success = false,
            };

            context.Result = new ObjectResult(response)
            {
                StatusCode = (int)statusCode
            };

            context.HttpContext.Response.StatusCode = (int)statusCode;
            context.ExceptionHandled = true;
        }
    }
}
