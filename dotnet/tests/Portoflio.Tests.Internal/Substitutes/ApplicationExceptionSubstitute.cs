using System.Net;
using Application.Abstractions;
using NSubstitute;

namespace Portoflio.Internal
{
    public static partial class PortfolioSubstitute
    {
        public class ApplicationException
        {
            internal static IApplicationException Default => Substitute.For<IApplicationException>();

            internal static IApplicationException New(HttpStatusCode statusCode, string exceptionMessage)
            {
                var substitute = Substitute.For<IApplicationException>();
                substitute.StatusCode.Returns(statusCode);
                substitute.Message.Returns(exceptionMessage);

                return substitute;
            }
        } 
    }
}