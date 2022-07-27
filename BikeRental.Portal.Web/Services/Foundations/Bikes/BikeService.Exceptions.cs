using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeRental.Portal.Web.Brokers.Apis;
using BikeRental.Portal.Web.Brokers.Loggings;
using BikeRental.Portal.Web.Models.Bikes;
using BikeRental.Portal.Web.Models.Bikes.Exceptions;
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
    }

	private BikeValidationException CreateAndLogValidationException(Xeption exception)
	{
		var bikeValidationException = 
			new BikeValidationException(exception);

        this.loggingBroker.LogError(bikeValidationException);

        return bikeValidationException;
	}
}
