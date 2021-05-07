using System.Net;

namespace Api.Abstractions
{
    public interface IApplicationException
    {
        HttpStatusCode StatusCode { get; }
    }
}