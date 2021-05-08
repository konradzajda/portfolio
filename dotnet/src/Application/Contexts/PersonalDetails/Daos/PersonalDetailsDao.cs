using System;

namespace Application.Daos
{
    public class PersonalDetailsDao : IUnique<long>, ITrackable
    {
        public long Id { get; init; }

        public DateTime CreationDateUtc { get; init; }

        public DateTime UpdateDateUtc { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public DateTime BirthDate { get; init; }

        public string Location { get; init; }
    }

    public interface ITrackable
    {
        DateTime CreationDateUtc { get; }

        DateTime UpdateDateUtc { get; }
    }

    public interface IUnique<out T>
    {
        T Id { get; }
    }
}