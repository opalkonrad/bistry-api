using BistryApi.Administrator;
using BistryApi.Authorization;
using BistryApi.Configuration;
using BistryApi.MenuItems;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var configuration = builder.Configuration;

builder.Services.AddCors(x => x.AddPolicy("AllowAnyCorsPolicy", options =>
{
    options.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SecurityTokenValidators.Clear();

    var clientId = configuration.GetSection("GoogleOAuth")["ClientId"];
    options.SecurityTokenValidators.Add(new GoogleTokenValidator(clientId));
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
    {
        policy.Requirements.Add(new AdminRequirement());
    });
});

builder.Services.Configure<CosmosDbConfiguration>(configuration.GetSection("CosmosDbConfiguration"));

builder.Services.AddDbContext<BistryContext>(options =>
{
    var cosmosDbConfiguration = configuration.GetSection("CosmosDbConfiguration");

    var uri = cosmosDbConfiguration["Uri"];
    var key = cosmosDbConfiguration["Key"];
    var databaseId = cosmosDbConfiguration["DatabaseId"];

    options.UseCosmos(uri, key, databaseId);
});

builder.Services.AddTransient<IAuthorizationHandler, AdminHandler>();
builder.Services.AddTransient<IAdminStore, AdminStore>();
builder.Services.AddTransient<IMenuItemsStore, MenuItemsStore>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAnyCorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
