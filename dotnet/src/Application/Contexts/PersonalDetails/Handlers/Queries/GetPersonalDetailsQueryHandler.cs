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
using Application.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.PersonalDetails
{
    /// <summary>
    /// Handler of the <see cref="GetPersonalDetailsQuery"/>.
    /// </summary>
    public class GetPersonalDetailsQueryHandler : IRequestHandler<GetPersonalDetailsQuery, IResult<PersonalDetailsResource>>
    {
        private readonly IPersonalDetailsContext context;
        private readonly IMapper mapper;

        public GetPersonalDetailsQueryHandler(IPersonalDetailsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public Task<IResult<PersonalDetailsResource>> Handle(GetPersonalDetailsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return this.HandleInternal(cancellationToken);
        }

        private async Task<IResult<PersonalDetailsResource>> HandleInternal(CancellationToken token)
        {
            var details = await this.context.Personals
                .ProjectTo<PersonalDetailsResource>(this.mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(token);

            if (details == null)
            {
                return ApplicationResult.FromException<PersonalDetailsResource>(
                    ApplicationExceptions.NotFound);
            }

            return ApplicationResult.FromResource(details);
        }
    }
}