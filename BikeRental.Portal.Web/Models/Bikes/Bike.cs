using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BikeRental.Portal.Web.Models.Bikes;
public class Bike
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public Category Category { get; set; }
    public string Notes { get; set; }
    public decimal FirstHour { get; set; }
    public decimal AdditionalHour { get; set; }
    public DateTimeOffset PruchaseDate { get; set; }
    public DateTimeOffset DateOfLastService { get; set; }
}
