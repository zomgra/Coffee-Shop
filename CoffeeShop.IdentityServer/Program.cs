using CoffeeShop.IdentityServer;
using CoffeeShop.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(p =>
    {
        p.AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("http://localhost:3000")
        .AllowCredentials();
    });
});
builder.Services.AddRazorPages();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(config =>
{
    config.User.RequireUniqueEmail = false;
    config.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
    config.Password.RequireDigit = false;
    config.Password.RequireLowercase = false;
    config.Password.RequireNonAlphanumeric = false;
    config.Password.RequireUppercase = false;
    config.Password.RequiredLength = 6;
})
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

builder.Services.AddIdentityServer()

    .AddAspNetIdentity<ApplicationUser>()
        .AddInMemoryApiResources(Configuration.GetApiResources())
       .AddInMemoryIdentityResources(Configuration.GetIdentityResources())
       .AddInMemoryClients(Configuration.GetClients())
       .AddInMemoryApiScopes(Configuration.GetScopes())
       .AddDeveloperSigningCredential();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Auth/Login";
    config.LogoutPath = "/Auth/Logout";
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseIdentityServer();
app.MapDefaultControllerRoute();

var scope = app.Services.CreateScope();
DbInitialize.Initial(scope.ServiceProvider.GetService<ApplicationDbContext>());

app.Run();
