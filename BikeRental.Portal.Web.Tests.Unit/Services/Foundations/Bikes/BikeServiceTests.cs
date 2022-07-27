using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BikeRental.Portal.Web.Brokers.Apis;
using BikeRental.Portal.Web.Brokers.Loggings;
using BikeRental.Portal.Web.Models.Bikes;
using BikeRental.Portal.Web.Services.Foundations.Bikes;
using Moq;
using Tynamix.ObjectFiller;
using Xeptions;

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

    private static Expression<Func<Xeption,bool>> SameExceptionAs(Xeption expectedException) =>
           actucalException => actucalException.SameExceptionAs(expectedException);


    private static DateTimeOffset GetRandomDateTimeOffset() =>
        new DateTimeRange(earliestDate: new DateTime()).GetValue();

    private static Bike CreateRandomBike() =>
        CreateBikeFiller(GetRandomDateTimeOffset()).Create();

    private static Filler<Bike> CreateBikeFiller(DateTimeOffset dateTime)
    {
        var filler = new Filler<Bike>();

        filler.Setup().OnType<DateTimeOffset>().Use(dateTime);

        return filler;
    }
}
