using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeRental.Portal.Web.Brokers.Apis;
using BikeRental.Portal.Web.Brokers.Loggings;
using BikeRental.Portal.Web.Models.Bikes;
using BikeRental.Portal.Web.Models.Bikes.Exceptions;

namespace BikeRental.Portal.Web.Services.Foundations.Bikes;
public partial class BikeService
{
    private static void ValidateBikeIsNotNull(Bike bike)
    {
        if (bike is null)
        {
            throw new NullBikeException();

        }
    }
} 