using Microsoft.EntityFrameworkCore;
using TinyUrl.Data;
using TinyUrl.Service;
using TinyUrl.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("TinyUrlDatabase") ??
                       throw new InvalidOperationException("Connection string not found");

builder.Services.AddControllers();
builder.Services.AddDbContext<TinyUrlDbContext>(o => o.UseNpgsql(connectionString));
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITinyUrlService, TinyUrlService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();