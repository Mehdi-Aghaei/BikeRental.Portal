using BikeRental.Portal.Web.Models.Bikes;
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
