using CORE.Interfaces;
using CORE.Servicios;
using HELPERS;
using MODELS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Configuracion.CadenaConexxion = builder.Configuration.GetConnectionString("CadenaConexion");

builder.Services.AddTransient<IEmpleado, EmpleadoServicio>();
builder.Services.AddTransient<ICliente, ClienteServicio>();
builder.Services.AddTransient<IMembresias, MembresiasServicio>();
builder.Services.AddTransient<IPlanesEntrenamiento, PlanesEntrenamientoServicio>();
builder.Services.AddTransient<IFacturacion, FacturacionServicio>();
builder.Services.AddTransient<IVentas, VentasServicio>();
builder.Services.AddTransient<ISuplementos, SuplementosServicio>();


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
