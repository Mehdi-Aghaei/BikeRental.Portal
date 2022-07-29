using BikeRental.Portal.Web.Models.Bikes;
using BikeRental.Portal.Web.Services.Foundations.Bikes;
using Microsoft.AspNetCore.Components;

namespace BikeRental.Portal.Web.Views.Components;

public partial class Test
{
    [Parameter]
    public string Info { get; set; } = string.Empty;

    public Bike Bike { get; set; } = new Bike();

    [Inject]
    public IBikeService bikeService { get; set; }

    protected override Task OnInitializedAsync()
    {

        return base.OnInitializedAsync();
    }

    protected async Task HandleValidSubmit()
    {

    }
    protected async Task HandleInvalidSubmit()
    {

    }
}
