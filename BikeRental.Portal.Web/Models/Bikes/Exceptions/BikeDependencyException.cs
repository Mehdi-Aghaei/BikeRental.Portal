using Xeptions;

namespace BikeRental.Portal.Web.Models.Bikes.Exceptions;
public class BikeDependencyException : Xeption
{
    public BikeDependencyException(Xeption innerException)
        : base("Bike dependency error occurred, contact support.", innerException)
    {

    }

}
