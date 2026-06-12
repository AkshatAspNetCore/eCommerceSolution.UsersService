using ECommerceApp.Core;
using ECommerceApp.Core.Mappers;
using ECommerceApp.Infrastructure;
using ECommerceAppAPI.Middlewares;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:2929");
//Add Infrastructure Services
builder.Services.AddInfrastructure();
builder.Services.AddCore(builder.Configuration);

// === JWT Bearer authentication ===
// Validates incoming USER tokens issued by Entra External ID.
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // The "Authority" tells ASP.NET Core where to fetch the OpenID Connect
        // metadata (signing keys, supported algorithms). Microsoft auto-publishes
        // this at <authority>/.well-known/openid-configuration.
        options.Authority = "https://akshatwebuniversity.ciamlogin.com/6e6eaccf-7ddd-4bda-8560-c6d826e0c2bd/v2.0";

        options.TokenValidationParameters = new TokenValidationParameters
        {
            // Audiences our microservice will accept. We list both the old
            // frontend app reg (currently issuing tokens) and the new backend
            // app reg (will issue tokens after the migration completes).
            ValidAudiences = new[]
            {
                "api://f4922796-875f-43e1-b48b-a7771638c2f1",
                "f4922796-875f-43e1-b48b-a7771638c2f1",
                "api://862c37d8-f321-421b-aab5-ff256337f356",
                "862c37d8-f321-421b-aab5-ff256337f356"
            },
            ValidateIssuer = true,    // token's "iss" claim must match Authority
            ValidateAudience = true,  // token's "aud" must be in ValidAudiences
            ValidateLifetime = true,  // token must not be expired
        };
    });

builder.Services.AddAuthorization();

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
    config.AddProfile<ResgisterRequestMappingProfile>();
    config.AddProfile<ApplicationUserToUserDTOMappingProfile>();
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

