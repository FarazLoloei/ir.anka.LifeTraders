using Autofac;
using Autofac.Extensions.DependencyInjection;
using FastEndpoints.Swagger.Swashbuckle;
using FluentValidation.AspNetCore;
using ir.anka.LifeTraders.Fund.Infrastructure;
using ir.anka.LifeTraders.Trader.Infrastructure;
using ir.anka.LifeTraders.WebAPI.Infrastructure;
using Serilog;
using static ir.anka.LifeTraders.Common.Infrastructure.DefaultData.General;

using FundInfrastructure = ir.anka.LifeTraders.Fund.Infrastructure;
using TraderInfrastructure = ir.anka.LifeTraders.Trader.Infrastructure;

namespace ir.anka.LifeTraders.WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

        builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

        builder.Services.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(APPLICATION_VERSION, new Microsoft.OpenApi.Models.OpenApiInfo { Title = APPLICATION_TITLE, Version = APPLICATION_VERSION });
            c.EnableAnnotations();
            c.OperationFilter<FastEndpointsOperationFilter>();
        });

        string? connectionString = builder.Configuration.GetConnectionString("SqliteConnection");

        builder.Services.AddTraderDbContext(connectionString!);
        builder.Services.AddFundDbContext(connectionString!);

        builder.Services.AddFluentValidationAutoValidation()
                    .AddFluentValidationClientsideAdapters();

        builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
        {
            Trader.Core.ModulesBootstrapper.RegisterModules(containerBuilder);
            Fund.Core.ModulesBootstrapper.RegisterModules(containerBuilder);

            FundInfrastructure.ModulesBootstrapper.RegisterModules(containerBuilder, builder.Environment.EnvironmentName);
            TraderInfrastructure.ModulesBootstrapper.RegisterModules(containerBuilder, builder.Environment.EnvironmentName);

            ModulesBootstrapper.RegisterModules(containerBuilder);
        });

        //builder.Services.AddAuthentication();
        //builder.Services.AddAuthorization();
        builder.Services.AddRouting();

        var app = builder.Build();
        app.UseRouting();

        app.MapControllerRoute(
                    name: "default",
                    pattern: "/{controller}/{action=Index}/{id?}");

        app.UseSerilogRequestLogging();

        app.UseExceptionHandler(ExceptionMiddlewareHandler.HandleExceptions());

        app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/{APPLICATION_VERSION}/swagger.json", APPLICATION_TITLE));
        SwaggerBuilderExtensions.UseSwagger(app);

        app.MapSwagger();
        app.UseSwaggerUI();

        app.Run();
    }
}