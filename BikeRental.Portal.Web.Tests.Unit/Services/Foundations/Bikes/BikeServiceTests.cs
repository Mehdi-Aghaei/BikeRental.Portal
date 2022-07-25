using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeRental.Portal.Web.Brokers.Apis;
using BikeRental.Portal.Web.Brokers.Loggings;
using BikeRental.Portal.Web.Models.Bikes;
using BikeRental.Portal.Web.Services.Foundations;
using Moq;
using Tynamix.ObjectFiller;

namespace BikeRental.Portal.Web.Tests.Unit.Services.Foundations.Bikes;
public partial class BikeServiceTests
{
    private readonly Mock<IApiBroker> apiBrokerMock;
    private readonly Mock<ILoggingBroker> loggingBrokerMock;
    private readonly IBikeService bikeService;

    public BikeServiceTests()
    {
        this.apiBrokerMock = new Mock<IApiBroker>();
        this.loggingBrokerMock = new Mock<ILoggingBroker>();
        
        this.bikeService = new BikeService(
            this.apiBrokerMock.Object, 
            this.loggingBrokerMock.Object);
    }

    private static Filler<Bike> CreateBikeFiller() =>
        new Filler<Bike>();

}
