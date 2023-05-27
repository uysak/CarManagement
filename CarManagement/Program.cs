using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyInjection.Autofac;
using Business.Mapper;
using DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);

//Automapper

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);


//Autofac Configuration
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));


// Add services to the container.

builder.Services.AddControllers();
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

using (var db = new CarsContext())
{
    EfDbInitializer.Migrate(db);
    EfDbInitializer.Initialize(db);
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
