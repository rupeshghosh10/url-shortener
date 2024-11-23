using Microsoft.EntityFrameworkCore;
using TinyUrl.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<TinyUrlDbContext>(o =>
    o.UseNpgsql("Server=localhost;Port=5432;Username=postgres;Password=root;Database=tinyurl;"));

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();