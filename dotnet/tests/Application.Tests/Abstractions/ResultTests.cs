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
            IResult<int> concrete = new Result
            {
                Exception = Substitute.For<IApplicationException>(),
            };

            // When
            var result = concrete.Success;

            // Then
            result.Should().BeFalse();
        }

        private class Result : IResult<int>
        {
            public int Resource { get; init; }

            public IApplicationException Exception { get; init; }
        }
    }
}