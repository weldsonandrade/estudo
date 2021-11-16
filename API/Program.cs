using Data.Implementations.DbClient;
using Data.Implementations.Repository;
using Data.Interfaces.DbClient;
using Data.Interfaces.Repository;
using Service.Implementations;
using Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IContratoRepository, ContratoRepository>();

builder.Services.AddScoped<IContratoService, ContratoServices>();

builder.Services.AddSingleton<IDbClient, DbClient>();

builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoDbConfig>(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwaggerUI();

app.UseSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
