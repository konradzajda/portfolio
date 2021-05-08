// <copyright file="ITrackable.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System;

namespace Application.Abstractions
{
    /// <summary>
    /// Defines properties for an object which updates are trackable in time.
    /// </summary>
    public interface ITrackable
    {
        /// <summary>
        /// Gets a date of object's creation, expressed as Coordinated Universal Time (UTC).
        /// </summary>
        DateTime CreationDateUtc { get; }

        /// <summary>
        /// Gets a date of object's last update, expressed as Coordinated Universal Time (UTC).
        /// </summary>
        DateTime UpdateDateUtc { get; }
    }
}