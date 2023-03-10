using Microsoft.EntityFrameworkCore;
using SM.Api.Contractors;
using SM.Api.DataAccess;
using SM.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionstring = builder.Configuration.GetConnectionString("DEV_SQL_CON");
builder.Services.AddDbContext<SMDbContext>(options => options.UseSqlServer(connectionstring));
builder.Services.AddScoped<ICommonService, CommonService>();
builder.Services.AddScoped<IUtilityService, UtilityService>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
