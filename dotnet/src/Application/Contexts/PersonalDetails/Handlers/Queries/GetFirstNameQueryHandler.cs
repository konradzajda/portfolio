// <copyright file="GetFirstNameQueryHandler.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

using Application.Abstractions;
using Application.Internal;
using Application.Queries.PersonalDetails;
using MediatR;

namespace Application.Handlers.PersonalDetails
{
    /// <summary>
    /// Handler of the <see cref="GetFirstNameQuery"/>.
    /// </summary>
    public class GetFirstNameQueryHandler : IRequestHandler<GetFirstNameQuery, IResult<string>>
    {
        /// <inheritdoc/>
        public Task<IResult<string>> Handle(GetFirstNameQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(ApplicationResult.FromResource(string.Empty));
        }
    }
}