// <copyright file="ApplicationResultTests.cs" company="Konrad Zajda">
// Copyright (c) Konrad Zajda. All rights reserved.
// </copyright>

using System;

using Api.Abstractions;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Application.Internal
{
    public class ApplicationResultTests
    {
        [Fact]
        public void FromResource_ShouldThrowArgumentNullException_WhenResourceIsNull()
        {
            // When
            Action call = () => ApplicationResult.FromResource<string>(null);

            // Then
            call.Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("resource");
        }

        [Fact]
        public void FromResource_ShouldReturnSuccessfulResult()
        {
            // Given
            const string resource = nameof(resource);

            // When
            var result = ApplicationResult.FromResource(resource);

            // Then
            result.Success.Should().BeTrue();
        }

        [Fact]
        public void FromException_ShouldThrowArgumentNullException_WhenExceptionIsNull()
        {
            // When
            Action call = () => ApplicationResult.FromException<string>(null!);

            // Then
            call.Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("exception");
        }

        [Fact]
        public void FromException_ShouldReturnFailedResult()
        {
            // When
            var result = ApplicationResult.FromException<string>(Substitute.For<IApplicationException>());

            // Then
            result.Success.Should().BeFalse();
        }

        [Fact]
        public void FromException_ShouldSetValidExceptionValue()
        {
            // Given
            var exception = Substitute.For<IApplicationException>();

            // When
            var result = ApplicationResult.FromException<string>(exception);

            // Then
            result.Exception.Should().Be(exception);
        }

        [Fact]
        public void FromResource_ShouldSetValidResource()
        {
            // Given
            object resource = new ();

            // When
            var result = ApplicationResult.FromResource(resource);

            // Then
            result.Resource.Should().Be(resource);
        }
    }
}