using Xeptions;

namespace BikeRental.Portal.Web.Models.Bikes.Exceptions;
public class NullBikeException : Xeption
{
    public NullBikeException()
        : base("Bike is null")
    { }
}
