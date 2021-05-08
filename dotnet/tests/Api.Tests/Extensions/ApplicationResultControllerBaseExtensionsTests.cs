// <copyright file="ApplicationResultControllerBaseExtensionsTests.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System.Net;

using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Portoflio.Internal;
using Xunit;

namespace Api.Extensions
{
    public class ApplicationResultControllerBaseExtensionsTests
    {
        [Theory]
        [InlineData(HttpStatusCode.Conflict)]
        [InlineData(HttpStatusCode.BadRequest)]
        [InlineData(HttpStatusCode.UnprocessableEntity)]
        public void FromApplicationException_ShouldReturnActionResult_WithStatusCodeFromException(HttpStatusCode code)
        {
            // Given
            var result = PortfolioSubstitute.Result.FromException<string>(code);

            // When
            var actionResult = new ControllerConcrete().FromApplicationException(result);

            // Then
            actionResult.Should().BeOfType<ObjectResult>()
                .Which.StatusCode.Should().Be((int)code);
        }

        [Fact]
        public void FromApplicationException_ShouldReturnActionResult_WithMessageFromException()
        {
            // Given
            const string message = nameof(message);
            var result = PortfolioSubstitute.Result.FromException<string>(HttpStatusCode.NotFound, message);

            // When
            var actionResult = new ControllerConcrete().FromApplicationException(result);

            // Then
            actionResult.Should().BeOfType<ObjectResult>()
                .Which.Value.Should().BeOfType<string>().And.Be(message);
        }

        [Fact]
        public void FromApplicationException_ShouldReturnProblemActionResult_WhenResultIsSuccessful()
        {
            // Given
            var result = PortfolioSubstitute.Result.FromResource(string.Empty);
            result.Success.Returns(true);

            // When
            var actionResult = new ControllerConcrete().FromApplicationException(result);

            // Then
            actionResult.Should().BeOfType<StatusCodeResult>()
                .Which.StatusCode.Should().Be(500);
        }

        private class ControllerConcrete : ControllerBase
        {
        }
    }
}