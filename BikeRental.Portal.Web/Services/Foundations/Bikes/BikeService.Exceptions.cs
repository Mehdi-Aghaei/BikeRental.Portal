using BikeRental.Portal.Web.Models.Bikes;
using BikeRental.Portal.Web.Models.Bikes.Exceptions;
using RESTFulSense.Exceptions;
using Xeptions;

namespace BikeRental.Portal.Web.Services.Foundations.Bikes;
public partial class BikeService
{
    private delegate ValueTask<Bike> ReturningBikeFunction();

    private async ValueTask<Bike> TryCatch(ReturningBikeFunction returningBikeFunction)
    {
        try
        {
            return await returningBikeFunction();
        }
        catch (NullBikeException nullBikeException)
        {

            throw CreateAndLogValidationException(nullBikeException);
        }
        catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
        {
            var failedBikeDependencyException =
                new FailedBikeDependencyException(httpResponseUrlNotFoundException);

            throw CreateAndLogCriticalDependencyException(failedBikeDependencyException);
        }
        catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
        {
            var failedBikeDependencyException =
                new FailedBikeDependencyException(httpResponseUnauthorizedException);

            throw CreateAndLogCriticalDependencyException(failedBikeDependencyException);
            
        }
        catch (HttpResponseForbiddenException httpResponseForbiddenException)
        {
            var failedBikeDependencyException =
                new FailedBikeDependencyException(httpResponseForbiddenException);

            throw CreateAndLogCriticalDependencyException(failedBikeDependencyException);
        }
    }

    private BikeDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
    {
        var bikeDependencyException = 
            new BikeDependencyException(exception);

        this.loggingBroker.LogCritical(bikeDependencyException);

        return bikeDependencyException;
    }

    private BikeValidationException CreateAndLogValidationException(Xeption exception)
    {
        var bikeValidationException =
            new BikeValidationException(exception);

        this.loggingBroker.LogError(bikeValidationException);

        return bikeValidationException;
    }
}
