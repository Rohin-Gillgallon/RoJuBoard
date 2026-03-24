using Microsoft.EntityFrameworkCore;
using RoJu.Api.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RoJuDBContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddSignalR();

builder.Services.AddCors(options => {
    options.AddPolicy("Open", builder => {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("Open");
app.UseAuthorization();
app.MapControllers();
app.Run();



