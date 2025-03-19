// // var builder = WebApplication.CreateBuilder(args);

// // // Add services to the container.
// // // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// // builder.Services.AddEndpointsApiExplorer();
// // builder.Services.AddSwaggerGen();

// // var app = builder.Build();

// // // Configure the HTTP request pipeline.
// // if (app.Environment.IsDevelopment())
// // {
// //     app.UseSwagger();
// //     app.UseSwaggerUI();
// // }

// // app.UseHttpsRedirection();

// // var summaries = new[]
// // {
// //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// // };

// // // app.MapGet("/weatherforecast", () =>
// // // {
// // //     var forecast =  Enumerable.Range(1, 5).Select(index =>
// // //         new WeatherForecast
// // //         (
// // //             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
// // //             Random.Shared.Next(-20, 55),
// // //             summaries[Random.Shared.Next(summaries.Length)]
// // //         ))
// // //         .ToArray();
// // //     return forecast;
// // // })
// // // .WithName("GetWeatherForecast")
// // // .WithOpenApi();

// // // app.Run();

// // // record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// // // {
// // //     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// // // }
 

// using Microsoft.EntityFrameworkCore;
// using EmployeeAPI.Data;

// var builder = WebApplication.CreateBuilder(args);

// // Explicitly load configuration
// builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// // Check if connection string exists
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// if (string.IsNullOrEmpty(connectionString))
// {
//     throw new InvalidOperationException("Connection string 'DefaultConnection' is missing.");
// }

// // Add services to the container
// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAll",
//         policy => policy.AllowAnyOrigin()
//                         .AllowAnyMethod()
//                         .AllowAnyHeader());
// });

// // Configure Entity Framework Core
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseSqlServer(connectionString));

// var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseCors("AllowAll");
// app.UseAuthorization();
// app.MapControllers();
// app.Run();







using Microsoft.EntityFrameworkCore;
using UserAuthAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Add Database Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 Configure Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();




      // "applicationUrl": "http://localhost:5267",
      //"applicationUrl": "https://localhost:7265;http://localhost:5267",
