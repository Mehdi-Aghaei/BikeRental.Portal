using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeRental.Portal.Web.Brokers.Apis;
using BikeRental.Portal.Web.Brokers.Loggings;
using BikeRental.Portal.Web.Models.Bikes;
using BikeRental.Portal.Web.Models.Bikes.Exceptions;
using BikeRental.Portal.Web.Services.Foundations;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
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
}
