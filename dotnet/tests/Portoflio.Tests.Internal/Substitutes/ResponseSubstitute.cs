using System.Net;
using Application.Abstractions;
using NSubstitute;

namespace Portoflio.Internal
{
    public static partial class PortfolioSubstitute 
    {
        public class Result
        {
            public static IResult<T> FromResource<T>(T resource)
            {
                var substitute = Substitute.For<IResult<T>>();
                substitute.Resource.Returns(resource);

                return substitute;
            }

            public static IResult<T> FromException<T>(IApplicationException exception = null)
            {
                exception ??= ApplicationException.Default;
                
                var substitute = Substitute.For<IResult<T>>();
                substitute.Exception.Returns(exception);

                return substitute;
            }

            public static IResult<T> FromException<T>(HttpStatusCode statusCode, string message = null)
            {
                message ??= string.Empty;
                var exception = ApplicationException.New(statusCode, message);
                return FromException<T>(exception);
            }
        }
    }
}