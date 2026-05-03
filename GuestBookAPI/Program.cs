using GuestBookAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GuestBookContext>(options => options.UseSqlite("Data Source=guestbook.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    // Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
