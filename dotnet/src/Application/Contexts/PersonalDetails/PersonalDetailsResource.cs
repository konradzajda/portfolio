// <copyright file="PersonalDetailsResource.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System;

namespace Application.Resources
{
    /// <summary>
    /// Represents a resource of the personal details belonging to some person.
    /// An resource is an object managed in application layer from the presentation layer.
    /// </summary>
    public class PersonalDetailsResource
    {
        /// <summary>
        /// Gets a first name of the person.
        /// </summary>
        public string FirstName { get; init; }

        /// <summary>
        /// Gets a last name of the person.
        /// </summary>
        public string LastName { get; init; }

        /// <summary>
        /// Gets a birthdate of the person.
        /// </summary>
        public DateTime BirthDate { get; init; }

        /// <summary>
        /// Gets a current location of the person.
        /// </summary>
        public string Location { get; init; }
    }
}