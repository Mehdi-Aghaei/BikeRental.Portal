using System.Linq.Expressions;
using BikeRental.Portal.Web.Brokers.Apis;
using BikeRental.Portal.Web.Brokers.Loggings;
using BikeRental.Portal.Web.Models.Bikes;
using BikeRental.Portal.Web.Services.Foundations.Bikes;
using Moq;
using RESTFulSense.Exceptions;
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

    public static TheoryData CriticalDependencyExceptions()
    {
        string someMessage = GetRandomString();
        var someResponseMessage = new HttpResponseMessage();

        return new TheoryData<Xeption>()
            {
                new HttpResponseUrlNotFoundException(someResponseMessage, someMessage),
                new HttpResponseUnauthorizedException(someResponseMessage, someMessage),
                new HttpResponseForbiddenException(someResponseMessage, someMessage),
            };
    }

    private static string GetRandomString() =>
        new MnemonicString().GetValue();

    private static Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
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
    private static Dictionary<string, List<string>> CreateRandomDictionary()
    {
        var filler = new Filler<Dictionary<string, List<string>>>();

        return filler.Create();
    }
}
