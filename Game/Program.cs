using Game.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<GameDbContext>();

var app = builder.Build();

app.MapControllers();

app.Run();