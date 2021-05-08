// <copyright file="GetPersonalDetailsQueryHandler.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;

using Application.Abstractions;
using Application.Internal;
using Application.Queries.PersonalDetails;
using Application.Resources;
using MediatR;

namespace Application.Handlers.PersonalDetails
{
    /// <summary>
    /// Handler of the <see cref="GetPersonalDetailsQuery"/>.
    /// </summary>
    public class GetPersonalDetailsQueryHandler : IRequestHandler<GetPersonalDetailsQuery, IResult<PersonalDetailsResource>>
    {
        /// <inheritdoc/>
        public Task<IResult<PersonalDetailsResource>> Handle(GetPersonalDetailsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var details = new PersonalDetailsResource
            {
                FirstName = "Konrad",
                LastName = "Zajda",
                BirthDate = new DateTime(1997, 3, 22),
                Location = "Gdańsk",
            };

            return Task.FromResult(ApplicationResult.FromResource(details));
        }
    }
}