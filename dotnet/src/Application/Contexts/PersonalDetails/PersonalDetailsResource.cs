using System;

namespace Application.Resources
{
    public class PersonalDetailsResource
    {
        public string FirstName { get; init; }

        public string LastName { get; init; }

        public DateTime BirthDate { get; init; }

        public string Location { get; set; }
    }
}