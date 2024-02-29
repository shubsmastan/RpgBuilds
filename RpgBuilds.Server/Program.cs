using System.Data.Common;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<DbConnection>(builder.Configuration.GetSection(key:"DatabaseSettings"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
// if (connectionString == null)
// {
//     Console.WriteLine("You must set your 'MONGODB_URI' environment variable.");
//     Environment.Exit(0);
// }
// var client = new MongoClient(connectionString);

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
