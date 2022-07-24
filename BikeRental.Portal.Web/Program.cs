using BikeRental.Portal.Web.Brokers.Apis;

namespace Company.WebApplication1;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages(options =>
        {
            options.RootDirectory = "/Views/Pages";
        });

        builder.Services.AddServerSideBlazor();
        builder.Services.AddScoped<IApiBroker, ApiBroker>();
        builder.Services.AddLogging();
        builder.Services.AddHttpClient();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.Run();
    }
}