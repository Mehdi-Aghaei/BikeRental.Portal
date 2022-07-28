using BikeRental.Portal.Web.Models.Bikes;
using BikeRental.Portal.Web.Models.Bikes.Exceptions;
using FluentAssertions;
using Moq;

namespace BikeRental.Portal.Web.Tests.Unit.Services.Foundations.Bikes;
public partial class BikeServiceTests
{
    [Fact]
    public async Task ShouldThrowValidationExceptionOnAddIfBikeIsNullAndLogItAsync()
    {
        // given
        Bike nullBike = null;

        var nullBikeException =
            new NullBikeException();

        var expectedBikeValidationException =
            new BikeValidationException(nullBikeException);

        // when
        ValueTask<Bike> addBikeTask = this.bikeService.AddBikeAsync(nullBike);

        var actualBikeValidationException =
            await Assert.ThrowsAsync<BikeValidationException>(
                addBikeTask.AsTask);

        // then
        actualBikeValidationException.Should().BeEquivalentTo(expectedBikeValidationException);

        this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(
                expectedBikeValidationException))),
                    Times.Once);

        this.apiBrokerMock.Verify(broker =>
            broker.PostBikeAsync(It.IsAny<Bike>()),
                Times.Never);

        this.loggingBrokerMock.VerifyNoOtherCalls();
        this.apiBrokerMock.VerifyNoOtherCalls();
    }
}
