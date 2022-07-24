using Microsoft.AspNetCore.Components;

namespace BikeRental.Portal.Web.Views.Components;

public partial class Test
{
    [Parameter]
    public string Info { get; set; } = string.Empty;
}
