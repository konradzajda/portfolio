// <copyright file="GetPersonalDetailsQuery.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using Application.Abstractions;
using Application.Resources;
using MediatR;

namespace Application.Queries.PersonalDetails
{
    /// <summary>
    /// Defines query for getting first name.
    /// </summary>
    public sealed class GetPersonalDetailsQuery : IRequest<IResult<PersonalDetailsResource>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetPersonalDetailsQuery"/> class.
        /// </summary>
        /// <param name="personId">Unique identifier of the person to find.</param>
        public GetPersonalDetailsQuery(ulong personId)
        {
            this.PersonId = personId;
        }

        /// <summary>
        /// Gets a unique identifier of the person to find.
        /// </summary>
        public ulong PersonId { get; }
    }
}