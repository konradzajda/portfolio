using System.Net;
using Application.Abstractions;

namespace Application.Internal
{
    public static class ApplicationExceptions
    {
        private class AppException : IApplicationException
        {
            public HttpStatusCode StatusCode { get; }

            public string Message { get; }

            public AppException(HttpStatusCode statusCode, string message)
            {
                StatusCode = statusCode;
                Message = message;
            }
        }

        public static IApplicationException NotFound => new AppException(HttpStatusCode.NotFound, string.Empty);
    }
}