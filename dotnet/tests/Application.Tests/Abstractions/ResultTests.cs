// <copyright file="ResultTests.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

#nullable enable
using Api.Abstractions;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Application.Abstractions
{
    public class ResultTests
    {
        [Fact]
        public void Success_ShouldReturnFalse_WhenExceptionIsNotNull()
        {
            // Given
            IResult<string> sut = new Result
            {
                Exception = Substitute.For<IApplicationException>(),
            };

            // When
            var result = sut.Success;

            // Then
            result.Should().BeFalse();
        }

        [Fact]
        public void Success_ShouldReturnTrue_WhenExceptionIsNull_And_ResourceNotEmpty()
        {
            // Given
            IResult<string> sut = new Result
            {
                Exception = null,
                Resource = "String",
            };

            // When
            var result = sut.Success;

            // Then
            result.Should().BeTrue();
        }

        [Fact]
        public void Success_ShouldReturnFalse_WhenResourceIsNull_AndExceptionIsNull()
        {
            // Given
            IResult<string> sut = new Result
            {
                Exception = null,
                Resource = null,
            };

            // When
            var result = sut.Success;

            // Then
            result.Should().BeFalse();
        }

        [Fact]
        public void Success_ShouldReturnFalse_WhenResourceIsNull_AndExceptionIsNotNull()
        {
            // Given
            IResult<string> sut = new Result
            {
                Exception = Substitute.For<IApplicationException>(),
                Resource = null,
            };

            // When
            var result = sut.Success;

            // Then
            result.Should().BeFalse();
        }

        private class Result : IResult<string>
        {
            public string? Resource { get; init; }

            public IApplicationException? Exception { get; init; }
        }
    }
}