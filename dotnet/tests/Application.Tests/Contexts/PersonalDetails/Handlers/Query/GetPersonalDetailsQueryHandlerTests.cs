// <copyright file="GetPersonalDetailsQueryHandlerTests.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;

using Application.Abstractions;
using Application.Handlers.PersonalDetails;
using Application.Queries.PersonalDetails;
using Application.Resources;
using Application.Services;
using AutoMapper;
using FluentAssertions;
using MediatR;
using NSubstitute;
using Xunit;

namespace Application.Contexts.PersonalDetails.Handlers.Query
{
    public class GetPersonalDetailsQueryHandlerTests
    {
        private readonly IRequestHandler<GetPersonalDetailsQuery, IResult<PersonalDetailsResource>> sut;

        public GetPersonalDetailsQueryHandlerTests()
        {
            this.sut = new GetPersonalDetailsQueryHandler(
                Substitute.For<IPersonalDetailsContext>(),
                Substitute.For<IMapper>());
        }

        [Fact]
        public async Task Handle_ShouldThrowOperationCancelledException_WhenCancellationRequested()
        {
            // Given
            var token = new CancellationToken(true);

            // When
            Func<Task> call = () => this.sut.Handle(null, token);

            // Then
            await call.Should().ThrowExactlyAsync<OperationCanceledException>();
        }

        [Fact]
        public async Task Handle_ShouldThrowArgumentNullException_WhenQueryIsNull()
        {
            // Given
            var token = new CancellationToken(false);

            // When
            Func<Task> call = () => this.sut.Handle(null, token);

            // Then
            await call.Should().ThrowExactlyAsync<ArgumentNullException>();
        }
    }
}