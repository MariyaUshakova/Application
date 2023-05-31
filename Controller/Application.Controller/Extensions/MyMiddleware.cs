using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using System;
using Application.Controller.Exceptions;

namespace Application.Controller.Extensions
{
    public class MyMiddleware
    {
        private readonly RequestDelegate next;

        public MyMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (GroupDoesNotExistException ex)
            {
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = (int)(HttpStatusCode.NotFound);
                await context.Response.WriteAsync(ex.Message);
            }
            catch (Exception)
            {
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("I met an error");
            }
        }

    }
}
