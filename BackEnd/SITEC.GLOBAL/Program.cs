using Microsoft.EntityFrameworkCore;
using SITEC.GLOBAL.BussinessLogic.Services;
using SITEC.GLOBAL.Controllers;
using SITEC.GLOBAL.Data.Context;
using SITEC.GLOBAL.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:8080",
                                              "http://192.168.100.40:8080")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                      });
});

builder.Services.AddDbContext<SitecDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SitecGlobalConnectionString")));

builder.Services.AddTransient<CustomAlumnoRepository>();
builder.Services.AddTransient<CustomSemestreRepository>();
builder.Services.AddTransient<AlumnoService>();
builder.Services.AddTransient<MateriaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
