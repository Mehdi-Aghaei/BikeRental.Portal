using Xeptions;

namespace BikeRental.Portal.Web.Models.Bikes.Exceptions;
public class BikeValidationException : Xeption
{
    public BikeValidationException(Xeption innerException)
        : base("Bike validation errors occurred, please try again.", innerException)
    { }
}
