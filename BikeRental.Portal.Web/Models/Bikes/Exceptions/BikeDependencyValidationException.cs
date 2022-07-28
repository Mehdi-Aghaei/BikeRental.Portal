using Xeptions;

namespace BikeRental.Portal.Web.Models.Bikes.Exceptions;
public class BikeDependencyValidationException : Xeption
{
    public BikeDependencyValidationException(Xeption innerException)
        : base("Bike dependency validation error occurred, contact support.", innerException)
    {

    }

}
