using Microsoft.EntityFrameworkCore;
using TinyUrl.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("TinyUrlDatabase") ??
                       throw new InvalidOperationException("Connection string not found");

builder.Services.AddControllers();
builder.Services.AddDbContext<TinyUrlDbContext>(o => o.UseNpgsql(connectionString));
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();