using Catalog.API.Data;
using Catalog.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddCarter();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IProductCatalogRepository, ProductRepository>();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddDbContext<ProductCatalogDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});

//builder.Services.AddMarten(opts =>
//{
//    opts.Connection(builder.Configuration.GetConnectionString("Database")!);

//}).UseLightweightSessions();

var app = builder.Build();

//Configure the HTTP request pipeline
//app.MapCarter();

app.MapControllers();

app.Run();
