// <copyright file="PersonalDetailsController.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

using Api.Personal.Views;
using Application.Queries.PersonalDetails;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Personal.Controllers
{
    /// <summary>
    /// An controller for managing personal details resources.
    /// </summary>
    [ApiController]
    [Route(Routes.PersonalPrefix)]
    public class PersonalDetailsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalDetailsController"/> class.
        /// </summary>
        /// <param name="mediator">A mediator, see <see cref="IMediator"/>.</param>
        /// <param name="mapper">A mapper, see <see cref="IMapper"/>.</param>
        public PersonalDetailsController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets person's first name.
        /// </summary>
        /// <param name="id">Unique identifier of the person to look for.</param>
        /// <param name="token">A <see cref="CancellationToken"/> used for cancelling asynchronous operations.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonalDetails([FromRoute] ulong id, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var result = await this.mediator.Send(new GetPersonalDetailsQuery(id), token);

            if (result.Success)
            {
                var view = this.mapper.Map<PersonalDetailsViewModel>(result.Resource);
                return this.Ok(view);
            }

            return this.FromApplicationException(result);
        }
    }
}