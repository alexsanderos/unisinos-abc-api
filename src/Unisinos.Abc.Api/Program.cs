using Microsoft.EntityFrameworkCore;
using Unisinos.Abc.Api.Configuration;
using Unisinos.Abc.Domain.Interfaces;
using Unisinos.Abc.Infra.Data.Context;
using Unisinos.Abc.Infra.Data.Interfaces;
using Unisinos.Abc.Infra.Data.Queries;
using Unisinos.Abc.Infra.Data.Repositories;
using Unisinos.Abc.Infra.Interfaces;
using Unisinos.Abc.Infra.Services;
using Unisinos.Abc.Domain.Commands;
using Unisinos.Abc.Domain.EventsHandlers;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using Unisinos.Abc.Domain.Notifications;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<UnisinosAbcContext>(opt => opt.UseInMemoryDatabase("UnisinosAbcContext"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentQuery, StudentQuery>();
builder.Services.AddScoped<IVideoService, VideoService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddScoped<UnisinosAbcContext>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterMediatR(typeof(Program).Assembly);

    containerBuilder.RegisterType<CreateStudentCommand>().AsImplementedInterfaces();
    containerBuilder.RegisterType<BindStudentInCourseCommand>().AsImplementedInterfaces();

    containerBuilder.RegisterType<StudentCreatedNotification>().AsImplementedInterfaces();
    containerBuilder.RegisterType<BindStudentInCourseNotification>().AsImplementedInterfaces();

    containerBuilder.RegisterType<StudentCommandHandler>().AsImplementedInterfaces();
    containerBuilder.RegisterType<StudentEventHandler>().AsImplementedInterfaces();
});

var app = builder.Build();

IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<UnisinosAbcContext>();
DataTest.AddStudents(context);

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
