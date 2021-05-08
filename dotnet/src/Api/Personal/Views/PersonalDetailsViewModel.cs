using System;
using System.Text.Json.Serialization;

namespace Api.Personal.Views
{
    public sealed class PersonalDetailsViewModel
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; init; }

        [JsonPropertyName("last_name")]
        public string LastName { get; init; }

        [JsonPropertyName("birth_date")]
        public DateTime BirthDate { get; init; }

        [JsonPropertyName("location")]
        public string Location { get; init; }
    }
}