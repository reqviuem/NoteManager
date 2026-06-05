using Microsoft.EntityFrameworkCore;
using NoteManager.Data;
using NoteManager.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<INoteService, NoteService>();

var app = builder.Build();


app.UseCors();

app.MapControllers();

app.Run();
