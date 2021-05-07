// <copyright file="IResult.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

#nullable enable
namespace Api.Abstractions
{
    /// <summary>
    /// Defines properties for application's result of the request to the application layer.
    /// </summary>
    /// <typeparam name="T">Type of the resource requested.</typeparam>
    public interface IResult<out T>
    {
        /// <summary>
        /// Gets a requested resource.
        /// </summary>
        T? Resource { get; }

        /// <summary>
        /// Gets an application exception, see <see cref="IApplicationException"/>.
        /// </summary>
        IApplicationException? Exception { get; }

        /// <summary>
        /// Gets a value indicating whether application's response is successful.
        /// </summary>
        bool Success => this.Exception == null && this.Resource != null;
    }
}