using Xeptions;

namespace BikeRental.Portal.Web.Models.Bikes.Exceptions;
public class FailedBikeServiceException : Xeption
{
    public FailedBikeServiceException(Exception innerException)
        : base("Failed bike service error occurred, contact support.", innerException)
    {

    }
}
