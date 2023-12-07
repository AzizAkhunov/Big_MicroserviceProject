using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using YandexTaxi.Application;
using YandexTaxi.Infastructure.DbContexts;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddService();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<YandexTaxiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddMemoryCache();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();



app.UseAuthorization();

app.MapControllers();

app.Run();
