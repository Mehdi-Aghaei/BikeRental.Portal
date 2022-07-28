using Xeptions;

namespace BikeRental.Portal.Web.Models.Bikes.Exceptions;
public class BikeServiceException : Xeption
{
    public BikeServiceException(Xeption innerException)
        : base("Bike service errors occurred, please contact support.", innerException)
    { }
}
