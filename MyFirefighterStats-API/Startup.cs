// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API" file="Startup.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MyFirefighterStats.API;

using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyFirefighterStats.API.Data;

/// <summary>
///     Class used by the web host.
/// </summary>
public sealed class Startup
{
    private readonly IConfiguration configuration;

    public Startup(IConfiguration configuration) => this.configuration = configuration;

    /// <summary>
    ///     Configures the HTTP request pipeline
    /// </summary>
    /// <param name="app">Defines the application to be configured.</param>
    /// <param name="environment">Provides information about the web hosting environment.</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            _ = app.UseDeveloperExceptionPage();
        }

        _ = app.UseSwagger();
        _ = app.UseSwaggerUI(static c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyFirefighterStats.API v1"));

        _ = app.UseHttpsRedirection();

        _ = app.UseRouting();

        _ = app.UseAuthorization();

        _ = app.UseCors(static x => x.AllowAnyOrigin()
                                     .AllowAnyMethod()
                                     .AllowAnyHeader());

        _ = app.UseEndpoints(static endpoints => endpoints.MapControllers());
    }

    /// <summary>
    ///     Configures the services.
    /// </summary>
    /// <param name="services">A service collection</param>
    public void ConfigureServices(IServiceCollection services)
    {
        _ = services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

        _ = services.AddCors();

        _ = services.AddControllers()
                    .AddJsonOptions(static c => c.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        _ = services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

        _ = services.AddAutoMapper(typeof(Startup));

        _ = services.AddSwaggerGen(static c => c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "MyFirefighterStats-API",
            Version = "v1",
        }));
    }
}
