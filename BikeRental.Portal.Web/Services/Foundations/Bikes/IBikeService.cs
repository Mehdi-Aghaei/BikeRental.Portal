using BikeRental.Portal.Web.Models.Bikes;

namespace BikeRental.Portal.Web.Services.Foundations.Bikes;
public interface IBikeService
{
    ValueTask<Bike> AddBikeAsync(Bike bike);
}
