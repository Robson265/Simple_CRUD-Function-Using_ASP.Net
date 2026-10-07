using countries.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<CountriesDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("CountriesConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy =>
       policy.WithOrigins("https://localhost:7276; http://localhost:5157")
       .AllowAnyHeader()
       .AllowAnyMethod()
);

app.UseAuthorization();

app.MapControllers();

app.Run();
