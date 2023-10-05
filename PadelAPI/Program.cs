using MongoDB.Driver;
using PadelAPI.Models;
using PadelAPI.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

var mongoDBSettings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
builder.Services.AddSingleton<IMongoClient>(x => new MongoClient(mongoDBSettings.ConnectionString));
builder.Services.AddSingleton<IMongoDatabase>(x =>
    x.GetRequiredService<IMongoClient>().GetDatabase(mongoDBSettings.DatabaseName));
builder.Services.AddScoped<IPadelRepository, PadelRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
