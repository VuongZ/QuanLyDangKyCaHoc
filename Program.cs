using finalproject.Application.Interfaces;
using finalproject.Infrastructure.Repositories;
using finalproject.Presentation.Data;
using finalproject.Presentation.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddScoped<ISinhVienRepository, SinhVienRepository>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddGrpcReflection();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<SinhVienGrpcService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.MapGrpcReflectionService();
app.UseRouting();
app.Run();
