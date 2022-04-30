using Microsoft.EntityFrameworkCore;
using SmartMed.Infrastructure;
using SmartMed.Infrastructure.Medication;
using SmartMed.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<IMedicationService, MedicationService>();
builder.Services.AddTransient<IMedicationRepository, MedicationRepository>();
builder.Services.AddDbContext<SmartMedDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:sqlConnection").Value));

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
