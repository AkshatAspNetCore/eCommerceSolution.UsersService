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

//Add API documentation services (Swagger)
builder.Services.AddEndpointsApiExplorer();

//Add Swagger generation services to create Swagger documentation for the API
builder.Services.AddSwaggerGen();

//Add CORS services to allow cross-origin requests from the frontend application
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200") // Replace with your frontend URL
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

//Build the web application
var app = builder.Build();

// Exception handling middleware
app.UseExpectionHandlingMiddleware();

//Routing
app.UseRouting();

app.UseSwagger(); //Adds endpoint that can serve the Swagger.json
app.UseSwaggerUI(); //Adds endpoint that can serve the Swagger UI, which is a web-based interface for exploring and testing the API based on the Swagger.json documentation.
app.UseCors();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();

app.Run();

