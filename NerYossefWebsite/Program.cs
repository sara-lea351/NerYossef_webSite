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
builder.Services.AddTransient<IKollelRepository, KollelRepository>();
builder.Services.AddTransient<IKollelService, KollelService>();
builder.Services.AddTransient<IAlertRepository, AlertRepository>();
builder.Services.AddTransient<IAlertService, AlertService>();
builder.Services.AddTransient<IDocumentRepository, DocumentRepository>();
builder.Services.AddTransient<IDocumentService, DocumentService>();
builder.Services.AddTransient<IDocumentTypeRepository, DocumentTypeRepository>();
builder.Services.AddTransient<IDocumentTypeService, DocumentTypeService>();
builder.Services.AddTransient<IConfigurationRepository, ConfigurationRepository>();
builder.Services.AddTransient<IConfigurationService, ConfigurationService>();
builder.Services.AddTransient<IGroupRepository, GroupRepository>();
builder.Services.AddTransient<IGroupService, GroupService>();
builder.Services.AddTransient<IGroupMemberRepository, GroupMemberRepository>();
builder.Services.AddTransient<IGroupMemberService, GroupMemberService>();

builder.Services.AddTransient<studentValidation>();
builder.Services.AddTransient<kollelValidation>();
builder.Services.AddTransient<alertValidation>();
builder.Services.AddTransient<groupMemberValidation>();


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
        