using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeRental.Portal.Web.Brokers.Apis;
using BikeRental.Portal.Web.Brokers.Loggings;
using BikeRental.Portal.Web.Models.Bikes;
using BikeRental.Portal.Web.Services.Foundations;
using FluentAssertions;
using Force.DeepCloner;
using Moq;

namespace BikeRental.Portal.Web.Tests.Unit.Services.Foundations.Bikes;
public partial class BikeServiceTests
{
    [Fact]
    public async Task ShouldAddBikeAsync()
    {
        // given
        Bike randomBike = CreateRandomBike();
        Bike inputBike = randomBike;
        Bike postedBike = inputBike;
        Bike expectedBike = postedBike.DeepClone();

        this.apiBrokerMock.Setup(brokers =>
            brokers.PostBikeAsync(inputBike))
                .ReturnsAsync(postedBike);

        // when
        Bike actualBike = await this.bikeService.AddBikeAsync(inputBike);

        // then
        actualBike.Should().BeEquivalentTo(expectedBike);

        this.apiBrokerMock.Verify(broker =>
            broker.PostBikeAsync(inputBike),
                Times.Once);

        this.apiBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }
}
