using ApiLocadora.DataContext;
using ApiLocadora.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//config connectio database
var connectionString = builder.Configuration.GetConnectionString("dafault");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.
    UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    .UseSnakeCaseNamingConvention()
    );
var connectionsString = builder.Configuration.GetConnectionString("default");

builder.Services.AddDbContext<AppDbContext>(options =>
    options
    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    .UseSnakeCaseNamingConvention()
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*app.UseHttpsRedirection();*/

app.UseAuthorization();

app.MapControllers();

app.Run();
