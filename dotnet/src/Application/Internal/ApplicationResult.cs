// <copyright file="ApplicationResult.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

#nullable enable
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

using Application.Abstractions;

[assembly: InternalsVisibleTo("Application.Tests")]

namespace Application.Internal
{
    /// <summary>
    /// Contains static methods for initializing <see cref="IResult{T}"/>.
    /// </summary>
    internal static class ApplicationResult
    {
        /// <summary>
        /// Creates new successful <see cref="IResult{T}"/> with resource, see <see cref="IResult{T}.Resource"/>.
        /// </summary>
        /// <param name="resource">A resource, see <see cref="IResult{T}.Resource"/>.</param>
        /// <typeparam name="T">Type of the resource requested.</typeparam>
        /// <returns>A successful application result.</returns>
        /// <exception cref="ArgumentNullException">Thrown when resource is null.</exception>
        internal static IResult<T> FromResource<T>([NotNull] T resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            return new Result<T>
            {
                Resource = resource,
                Exception = null,
            };
        }

        /// <summary>
        /// Creates new failed <see cref="IResult{T}"/> with the application exception.
        /// </summary>
        /// <param name="exception">An application exception, see <see cref="IApplicationException"/>.</param>
        /// <typeparam name="TResult">Type of the generic argument of the <see cref="IResult{T}"/>.</typeparam>
        /// <returns>A failed application result.</returns>
        /// <exception cref="ArgumentNullException">Thrown when exception is null.</exception>
        internal static IResult<TResult> FromException<TResult>([NotNull] IApplicationException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            return new Result<TResult>
            {
                Resource = default,
                Exception = exception,
            };
        }

        private class Result<T> : IResult<T>
        {
            public T? Resource { get; init; }

            public IApplicationException? Exception { get; init; }
        }
    }
}