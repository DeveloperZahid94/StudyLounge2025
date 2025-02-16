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
builder.Services.AddScoped<ICabin, CabinRepo>();
builder.Services.AddScoped<IAssignment, AssignmentRepo>();
builder.Services.AddScoped<IFee, feeRepo>();



builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

    });
    //options.AddPolicy("SpecificPolicy", policy =>
    //policy.WithOrigins("https://yourfrontenddomain.com")
    //      .AllowAnyHeader()
    //      .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS before Authorization
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
