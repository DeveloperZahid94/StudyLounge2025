using Microsoft.EntityFrameworkCore;
using StudyLounge25.Data;
using StudyLounge25.Mapper;
using StudyLounge25.ServicesRepo.IServiceRepo;
using StudyLounge25.ServicesRepo.Repositories;
using System.Net;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<SLdbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConn")));

builder.Services.AddScoped<IStudent,StudentRepo>();
builder.Services.AddAutoMapper(typeof(MappingProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
