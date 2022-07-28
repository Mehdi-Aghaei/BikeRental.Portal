using System.Net.Http;
using BikeRental.Portal.Web.Models.Bikes;
using BikeRental.Portal.Web.Models.Bikes.Exceptions;
using FluentAssertions;
using Moq;
using RESTFulSense.Exceptions;
using Xeptions;

namespace BikeRental.Portal.Web.Tests.Unit.Services.Foundations.Bikes;
public partial class BikeServiceTests
{
    [Theory]
    [MemberData(nameof(CriticalDependencyExceptions))]
    public async Task ShouldThrowCriticalDependencyExceptionOnAddIfCriticalErrorOccursAndLogItAsync(
        Xeption criticalDependencyException)
    {
        // given
        var someBike = CreateRandomBike();

        var failedBikeDependencyException =
            new FailedBikeDependencyException(criticalDependencyException);

        var expectedBikeDependencyException = new BikeDependencyException(
            failedBikeDependencyException);

        this.apiBrokerMock.Setup(broker =>
            broker.PostBikeAsync(It.IsAny<Bike>()))
                .ThrowsAsync(criticalDependencyException);

        // when
        ValueTask<Bike> postBikeTask =
            this.bikeService.AddBikeAsync(someBike);

        var actualBikeDependencyException =
            await Assert.ThrowsAsync<BikeDependencyException>(postBikeTask.AsTask);

        // then
        actualBikeDependencyException.Should().BeEquivalentTo(expectedBikeDependencyException);

        this.apiBrokerMock.Verify(broker =>
            broker.PostBikeAsync(It.IsAny<Bike>()),
                Times.Once);

        this.loggingBrokerMock.Verify(broker =>
            broker.LogCritical(It.Is(SameExceptionAs(
                expectedBikeDependencyException))),
                    Times.Once);

        this.apiBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowDependencyValidationExceptionOnAddIfBadRequestExceptionOccursAndLogItAsync()
    {
        // given
        Bike randomBike = CreateRandomBike();
        var randomMessage = GetRandomString();
        var httpResponseMessage = new HttpResponseMessage();

        var randomDictionary = CreateRandomDictionary();

        var httpResponseBadRequestException =
            new HttpResponseBadRequestException(httpResponseMessage, randomMessage);

        httpResponseBadRequestException.AddData(randomDictionary);

        var invalidBikeException = 
            new InvalidBikeException(httpResponseBadRequestException, randomDictionary);

        var expectedBikeDependencyValidationException =
            new BikeDependencyValidationException(invalidBikeException);

        this.apiBrokerMock.Setup(broker =>
            broker.PostBikeAsync(It.IsAny<Bike>()))
                .ThrowsAsync(httpResponseBadRequestException);

        // when
        ValueTask<Bike> addBikeTask =
            this.bikeService.AddBikeAsync(randomBike);

        BikeDependencyValidationException actualBikeDependencyValidationException =
            await Assert.ThrowsAsync<BikeDependencyValidationException>(addBikeTask.AsTask);

        // then
        actualBikeDependencyValidationException.Should().BeEquivalentTo(expectedBikeDependencyValidationException);

        this.apiBrokerMock.Verify(broker =>
            broker.PostBikeAsync(It.IsAny<Bike>()), 
                Times.Once);

        this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(
                expectedBikeDependencyValidationException))),
                    Times.Once);

        this.apiBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowDependencyExceptionOnAddIfErrorOccursAndLogItAsync()
    {
        // given
        Bike randomBike = CreateRandomBike();
        string someMessage = GetRandomString();
        var someResponseMessage = new HttpResponseMessage();

        var httpResponseException =
            new HttpResponseException(someResponseMessage, someMessage);


        var failedBikeDependencyException =
            new FailedBikeDependencyException(httpResponseException);

        var expectedBikeDependencyException =
            new BikeDependencyException(failedBikeDependencyException);

        this.apiBrokerMock.Setup(broker =>
            broker.PostBikeAsync(It.IsAny<Bike>()))
                .ThrowsAsync(httpResponseException);

        // when
        ValueTask<Bike> addBikeTask =
            this.bikeService.AddBikeAsync(randomBike);

        var actualBikeDependencyException =
            await Assert.ThrowsAsync<BikeDependencyException>(addBikeTask.AsTask);

        // then
        actualBikeDependencyException.Should().BeEquivalentTo(expectedBikeDependencyException);

        this.apiBrokerMock.Verify(broker =>
            broker.PostBikeAsync(It.IsAny<Bike>()),
                Times.Once);

        this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(
                expectedBikeDependencyException))),
                    Times.Once);

        this.apiBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }
}
