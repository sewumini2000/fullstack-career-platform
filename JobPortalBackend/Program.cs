using JobPortalBackend.Data;
using JobPortalBackend.Repositories;
using JobPortalBackend.Repositories.impl;
using JobPortalBackend.Services;
using JobPortalBackend.Services.impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularLocalhost",
        policy => policy.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));



builder.Services.AddControllers();
builder.Services.AddScoped<IJobService , JobServiceImpl>();
builder.Services.AddScoped<IJobRepository , JobRepositoryImpl>();
builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAngularLocalhost");
app.MapControllers();
app.UseHttpsRedirection();
app.Run();