using BikeRental.Portal.Web.Brokers.Apis;
using BikeRental.Portal.Web.Brokers.Loggings;
using BikeRental.Portal.Web.Services.Foundations.Bikes;

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
        AddBrokers(builder);
        AddServices(builder);
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

        app.UseAuthentication();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.Run();
    }

    private static void AddBrokers(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IApiBroker, ApiBroker>();
        builder.Services.AddTransient<ILoggingBroker, LoggingBroker>();
    }
    private static void AddServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IBikeService, BikeService>();
    }
}