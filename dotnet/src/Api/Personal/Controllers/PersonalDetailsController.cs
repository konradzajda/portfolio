// <copyright file="PersonalDetailsController.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

using Application.Queries.PersonalDetails;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalDetailsController"/> class.
        /// </summary>
        /// <param name="mediator">A mediator, see <see cref="IMediator"/>.</param>
        public PersonalDetailsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets person's first name.
        /// </summary>
        /// <param name="token">A <see cref="CancellationToken"/> used for cancelling asynchronous operations.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IActionResult> GetFirstNameAsync(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var result = await this.mediator.Send(new GetFirstNameQuery(), token);

            if (result.Success)
            {
                return this.Ok(result.Resource);
            }

            return this.FromApplicationException(result);
        }
    }
}