// <copyright file="PersonalDetailsControllerTests.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;

using FluentAssertions;
using MediatR;
using NSubstitute;
using Xunit;

namespace Api.Personal.Controllers
{
    public class PersonalDetailsControllerTests
    {
        private readonly PersonalDetailsController sut;

        public PersonalDetailsControllerTests()
        {
            this.sut = new PersonalDetailsController(Substitute.For<IMediator>());
        }

        [Fact]
        public async Task GetFirstName_ShouldThrowOperationCancelledException_WhenCancellationRequested()
        {
            // Given
            var token = new CancellationToken(true);

            // When
            Func<Task> call = () => this.sut.GetFirstNameAsync(token);

            // Then
            await call.Should().ThrowExactlyAsync<OperationCanceledException>();
        }
    }
}