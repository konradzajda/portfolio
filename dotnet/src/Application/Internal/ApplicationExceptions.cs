// <copyright file="ApplicationExceptions.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System.Net;

using Application.Abstractions;

namespace Application.Internal
{
    /// <summary>
    /// Contains methods for creating predefined application exceptions.
    /// </summary>
    internal static class ApplicationExceptions
    {
        /// <summary>
        /// Gets an application exception which informs that requested resource was not found.
        /// </summary>
        public static IApplicationException NotFound => new AppException(HttpStatusCode.NotFound, string.Empty);

        private class AppException : IApplicationException
        {
            public AppException(HttpStatusCode statusCode, string message)
            {
                this.StatusCode = statusCode;
                this.Message = message;
            }

            public HttpStatusCode StatusCode { get; }

            public string Message { get; }
        }
    }
}