﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeRental.Portal.Web.Brokers.Apis;
using BikeRental.Portal.Web.Brokers.Loggings;
using BikeRental.Portal.Web.Models.Bikes;

namespace BikeRental.Portal.Web.Services.Foundations;
public class BikeService : IBikeService
{
    private readonly IApiBroker apiBroker;
    private readonly ILoggingBroker loggingBroker;

    public BikeService(IApiBroker apiBroker, ILoggingBroker loggingBroker)
    {
        this.apiBroker = apiBroker;
        this.loggingBroker = loggingBroker;
    }

    public ValueTask<Bike> AddBikeAsync(Bike bike)
    {
        throw new NotImplementedException();
    }
}
