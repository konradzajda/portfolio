namespace Api.Abstractions
{
    public interface IResult<out T>
    {
        T Resource { get; }

        IApplicationException Exception { get; }

        bool Success => this.Exception == null;
    }
}