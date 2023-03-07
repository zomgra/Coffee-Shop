using CoffeeShop.API;
using CoffeeShop.Application;
using CoffeeShop.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var urls = builder.Configuration.GetValue<string>("AllowedOrigin");

builder.Services.AddResponseCaching();
builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(p =>
    {
        p.AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins(urls)
        .AllowCredentials();
    });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateAudience = false
        };
        // URL of our identity server
        options.Authority = "https://localhost:10001";
        // HTTPS required for the authority (defaults to true but disabled for development).
        options.RequireHttpsMetadata = false;
        // the name of this API - note: matches the API resource name configured above
        options.Audience = "CoffeeService";
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseResponseCaching();

app.MapControllers();

var scope = app.Services.CreateScope();
DbInitializer.Initialize(scope);

app.Run();
