using BikeRental.Portal.Web.Models.Bikes;
using BikeRental.Portal.Web.Models.Configurations;
using Microsoft.Extensions.Hosting;
using RESTFulSense.Clients;

namespace BikeRental.Portal.Web.Brokers.Apis;
public partial class ApiBroker : IApiBroker
{
    private const string BikesRelativeUrl = "api/bikes";
    
    public async ValueTask<Bike> PostBikeAsync(Bike bike) =>
        await this.PostAsync(BikesRelativeUrl, bike);
}
