// <copyright file="PersonalDetailsDao.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System;

using Application.Abstractions;
using Application.Resources;

namespace Application.Daos
{
    /// <summary>
    /// Represents data access object for the <see cref="PersonalDetailsResource"/>.
    /// </summary>
    public class PersonalDetailsDao : IUnique<ulong>, ITrackable
    {
        /// <summary>
        /// Gets unique identifier, see <see cref="IUnique{T}.Id"/>.
        /// </summary>
        public ulong Id { get; init; }

        /// <summary>
        /// Gets creation date, see <see cref="ITrackable.CreationDateUtc"/>.
        /// </summary>
        public DateTime CreationDateUtc { get; init; }

        /// <summary>
        /// Gets a date of the last update, see <see cref="ITrackable.UpdateDateUtc"/>.
        /// </summary>
        public DateTime UpdateDateUtc { get; init; }

        /// <summary>
        /// Gets or sets a first name of the person.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets a last name of the person.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a birthdate of the person.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets a location of the person.
        /// </summary>
        public string Location { get; set; }
    }
}