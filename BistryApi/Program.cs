using BistryApi.Configuration;
using BistryApi.MenuItems;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var configuration = builder.Configuration;

builder.Services.Configure<CosmosDbConfiguration>(configuration.GetSection("CosmosDbConfiguration"));

builder.Services.AddDbContext<BistryContext>(options =>
{
    var cosmosDbConfiguration = configuration.GetSection("CosmosDbConfiguration");

    var uri = cosmosDbConfiguration["Uri"];
    var key = cosmosDbConfiguration["Key"];
    var databaseId = cosmosDbConfiguration["DatabaseId"];

    options.UseCosmos(uri, key, databaseId);
});

builder.Services.AddTransient<IMenuItemsStore, MenuItemsStore>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
