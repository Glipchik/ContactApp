using AutoMapper;
using ContactApp.Business.Interfaces;
using ContactApp.Business.Services;
using ContactApp.DAL.Context;
using ContactApp.DAL.Interfaces;
using ContactApp.DAL.Repositories;
using ContactApp.Web.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var options = new DbContextOptionsBuilder().Options;

builder.Services.AddDbContext<ApplicationDbContext>(_ => new ApplicationDbContext(options: options, configurationBuilder))
    .AddTransient<IContactRepository, ContactRepository>()
    .AddTransient<IUnitOfWork, UnitOfWork>()
    .AddTransient<IContactService, ContactService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    config.IncludeXmlComments(xmlPath);
});

var config = new MapperConfiguration(c =>
{
    c.AddProfile(new WebModelsMapper());
});

IMapper mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.RoutePrefix = string.Empty;
        config.SwaggerEndpoint("swagger/v1/swagger.json", "Contacts API");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
