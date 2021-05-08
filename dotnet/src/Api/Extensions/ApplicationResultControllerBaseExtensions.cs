// <copyright file="ApplicationResultControllerBaseExtensions.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using Application.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Mvc
{
    /// <summary>
    /// Contains extension methods for conversing see <see cref="IResult{T}"/> into <see cref="IActionResult"/>.
    /// </summary>
    public static class ApplicationResultControllerBaseExtensions
    {
        /// <summary>
        /// Creates new <see cref="IActionResult"/> from the <see cref="IResult{T}"/> containing application exception.
        /// </summary>
        /// <param name="controller">API controller.</param>
        /// <param name="result">Application result to create action result from.</param>
        /// <typeparam name="TResult">Generic type of the <see cref="IResult{T}"/>.</typeparam>
        /// <typeparam name="TController">Type of the controller.</typeparam>
        /// <returns>An action result.</returns>
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