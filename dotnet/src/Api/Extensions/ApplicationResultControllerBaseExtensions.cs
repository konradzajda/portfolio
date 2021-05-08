// <copyright file="ApplicationResultControllerBaseExtensions.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using Application.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Mvc
{
    public static class ApplicationResultControllerBaseExtensions
    {
        public static IActionResult FromApplicationException<TResult, TController>(this TController controller, IResult<TResult> result)
        where TController : ControllerBase
        {
            var exception = result.Exception;

            if (!result.Success && exception != null)
            {
                return controller.StatusCode((int)exception.StatusCode, exception.Message);
            }

            return controller.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}