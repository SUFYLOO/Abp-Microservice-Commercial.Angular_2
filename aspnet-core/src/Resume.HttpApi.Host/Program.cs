using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Resume;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        Log.Information("Starting Resume.HttpApi.Host.");
        var builder = WebApplication.CreateBuilder(args);

        Log.Logger = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .ReadFrom.Configuration(builder.Configuration)
            .WriteTo.Async(c => c.File($"Logs/logs{DateTime.Today.ToString("yyyyMMdd")}.txt"))
            //.WriteTo.Async(c => c.File("Logs/logs.txt"))
            //.WriteTo.MicrosoftTeams(webHookUri:"https://jbjob.webhook.office.com/webhookb2/ca47897d-6a74-4649-8bce-13a95f3138f4@d813e1be-6d67-43a2-9bf6-60916e68c549/IncomingWebhook/80d592fc3cb14d259bc9977a4b78d2fa/9816e357-0198-4c24-bdac-2cce0aeefe86",title: "JB-NB",restrictedToMinimumLevel: LogEventLevel.Warning)
            .WriteTo.Async(c => c.Console())
            .CreateLogger();

        try
        {

            builder.Host
                .AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog();
            await builder.AddApplicationAsync<ResumeHttpApiHostModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            if (ex is HostAbortedException)
            {
                throw;
            }

            Log.Fatal(ex, "Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
