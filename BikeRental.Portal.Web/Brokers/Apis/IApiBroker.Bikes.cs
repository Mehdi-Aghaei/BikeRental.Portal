using BikeRental.Portal.Web.Models.Bikes;

namespace BikeRental.Portal.Web.Brokers.Apis;
public partial interface IApiBroker
{
    ValueTask<Bike> PostBikeAsync(Bike bike);
}
