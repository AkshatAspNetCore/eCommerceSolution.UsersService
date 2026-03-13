using ECommerceApp.Core;
using ECommerceApp.Core.Mappers;
using ECommerceApp.Infrastructure;
using ECommerceAppAPI.Middlewares;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Add Infrastructure Services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add controllers to the service collection
builder.Services.AddControllers().AddJsonOptions(
    options => {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());
        });

//Add AutoMapper to the service collection
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<ApplicationUserMappingProfile>();
});

//FluentValidations
builder.Services.AddFluentValidationAutoValidation();

//Build the web application
var app = builder.Build();

// Exception handling middleware
app.UseExpectionHandlingMiddleware();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();

app.Run();

