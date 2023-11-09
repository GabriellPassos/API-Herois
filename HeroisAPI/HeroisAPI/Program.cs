using HeroisAPI.Validation;
using FluentValidation;
using HeroisAPI;
using HeroisAPI.Data;
using HeroisAPI.Models;
using Microsoft.EntityFrameworkCore;
using HeroisAPI.Services;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<HeroiService>(); 
builder.Services.AddScoped<SuperPoderService>();
builder.Services.AddScoped<IValidator<Heroi>, HeroiValidation>();
builder.Services.AddScoped<IValidator<SuperPoder>, SuperPoderValidation>();

var ConnectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                                             
                      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();
Router.Map(app);
app.Run();
public partial class Program { }