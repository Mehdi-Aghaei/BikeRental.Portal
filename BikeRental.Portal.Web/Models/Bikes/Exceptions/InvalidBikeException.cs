using System.Collections;
using Xeptions;

namespace BikeRental.Portal.Web.Models.Bikes.Exceptions;
public class InvalidBikeException : Xeption
{
    public InvalidBikeException()
            : base(message: "Invalid bike error occurred, please correct the errors and try again.")
    { }

    public InvalidBikeException(Exception innerException, IDictionary data)
        : base(message: "Invalid bike error occurred, please correct the errors and try again.",
              innerException,
              data)
    { }
}
