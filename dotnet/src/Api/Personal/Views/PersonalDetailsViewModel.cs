// <copyright file="PersonalDetailsViewModel.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System;
using System.Text.Json.Serialization;

namespace Api.Personal.Views
{
    /// <summary>
    /// Represents view model of the personal details.
    /// </summary>
    public sealed class PersonalDetailsViewModel
    {
        /// <summary>
        /// Gets my first name.
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; init; }

        /// <summary>
        /// Gets my second name.
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; init; }

        /// <summary>
        /// Gets my birthdate.
        /// </summary>
        [JsonPropertyName("birth_date")]
        public DateTime BirthDate { get; init; }

        /// <summary>
        /// Gets a name of the city I live in.
        /// </summary>
        [JsonPropertyName("location")]
        public string Location { get; init; }
    }
}