using Application.Interfaces.IQueries;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Application.Interfaces.ICommand;
using WebApplication1.Application.Interfaces.IQueries;
using WebApplication1.Application.Interfaces.IServices;
using WebApplication1.Application.Services;
using WebApplication1.Data;
using WebApplication1.Data.Commands;
using WebApplication1.Data.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibreriaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IAlquilerServices, AlquilerServices>();
builder.Services.AddTransient<IClienteServices, ClienteServices>();
builder.Services.AddTransient<ILibroServices, LibroServices>();

builder.Services.AddTransient<IQueryAlquiler, QueryAlquiler>();
builder.Services.AddTransient<IQueryCliente, QueryCliente>();
builder.Services.AddTransient<IQueryLibro, QueryLibro>();
builder.Services.AddTransient<IQueryEstadoAlquiler, QueryEstadoAlquiler>();

builder.Services.AddTransient<IAlquilerCommand, AlquilerCommand>();
builder.Services.AddTransient<IClienteCommand, ClienteCommand>();

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthorization();
app.MapControllers();
app.Run();