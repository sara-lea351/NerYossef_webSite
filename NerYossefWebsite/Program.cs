using Microsoft.EntityFrameworkCore;
using NerYossefWebsite.Models;
using NerYossefWebsite.Repositories;
using NerYossefWebsite.Services;
using NerYossefWebsite.Services.ServiceValidations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<studentValidation>();
builder.Services.AddDbContext<NerYossefDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings"]));
         
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
        