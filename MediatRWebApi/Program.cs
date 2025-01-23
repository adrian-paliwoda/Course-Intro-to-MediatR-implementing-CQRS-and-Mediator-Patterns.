using DemoLibrary;
using DemoLibrary.DataAccess;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddNewtonsoftJson();

builder.Services
    .AddSingleton<IDataAccess, DemoDataAccess>()
    .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MediatREntryPoint).Assembly))
    .AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

}
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
