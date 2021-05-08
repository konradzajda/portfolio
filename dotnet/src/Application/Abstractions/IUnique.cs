// <copyright file="IUnique.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

namespace Application.Abstractions
{
    /// <summary>
    /// Defines properties for a type which instances are unique and their uniqueness can be
    /// verified by their unique key.
    /// </summary>
    /// <typeparam name="T">Type of the key.</typeparam>
    public interface IUnique<out T>
    {
        /// <summary>
        /// Gets a unique identifier of the object, which is unique across all instances of it's type.
        /// </summary>
        T Id { get; }
    }
}