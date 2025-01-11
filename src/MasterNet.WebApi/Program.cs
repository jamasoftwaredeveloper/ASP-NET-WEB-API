using MasterNet.Application;
using MasterNet.Application.Interfaces;
using MasterNet.Infrastructure.Photos;
using MasterNet.Infrastructure.Reports;
using MasterNet.Persistence;
using MasterNet.Persistence.Models;
using MasterNet.WebApi.Extensions;
using MasterNet.WebApi.Middleware;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddPoliciesServices();

builder.Services.Configure<CloudinarySettings>(
    builder.Configuration.GetSection("CloudinarySettings")
    );
builder.Services.AddScoped<IPhotoService, PhotoService>();

// builder.Services.AddScoped<IReportService, ReportService>(); Cuando no es generico
builder.Services.AddScoped(typeof(IReportService<>),typeof(ReportService<>)); //Inyecto un objecto de forma generica

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();

builder.Services.AddSwaggerDocumentation();

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

//Cors
builder.Services.AddCors(o => o.AddPolicy("corsapp", builder => {
    builder.WithOrigins("*").AllowAnyOrigin().AllowAnyHeader();
}));

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

/*
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/
app.useSwaggerDocumentation();


app.UseAuthentication();
app.UseAuthorization();

// Cors
app.UseCors("corsapp");

await app.SeedDataAuthentication();

app.MapControllers();
app.Run();