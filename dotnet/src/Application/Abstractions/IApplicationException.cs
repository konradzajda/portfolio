// <copyright file="IApplicationException.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System.Net;

namespace Application.Abstractions
{
    /// <summary>
    /// Defines properties for exception that was thrown in application layer.
    /// </summary>
    public interface IApplicationException
    {
        /// <summary>
        /// Gets a <see cref="HttpStatusCode"/> related to application's exception.
        /// </summary>
        HttpStatusCode StatusCode { get; }
    }
}