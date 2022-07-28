using Xeptions;

namespace BikeRental.Portal.Web.Models.Bikes.Exceptions;
public class FailedBikeDependencyException : Xeption
{
    public FailedBikeDependencyException(Exception innerException)
        : base("Failed bike dependency error occurred, contact support.", innerException)
    {

    }

}
