// See https://aka.ms/new-console-template for more information
using ManimaTech.Notification.Domain.Collections;
using ManimaTech.Notification.Domain.Collections.Interfaces;
using ManimaTech.Notification.Models.Settings;
using ManimaTech.Notification.Sender;
using ManimaTech.Notification.Services.Mandrill;
using ManimaTech.Notification.Services.Message;
using ManimaTech.Notification.Services.RabbitMQ;
using ManimaTech.Notification.Services.SendGrid;
using ManimaTech.Notification.Services.SendInBlue;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

Console.WriteLine("Notification Sender Initalizing!");

var configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.Development.json", optional: true)
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var appSettings = configurationBuilder.GetSection("AppSettings").Get<AppSettings>();

MongoClient mongoClient = new(appSettings.MongoDb.ConnectionString);

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services
        .AddSingleton<IMongoClient>((imp) => mongoClient)
        .AddScoped<IMessageCollection>(x => ActivatorUtilities.CreateInstance<MessageCollection>(x, x.GetRequiredService<IMongoClient>()))
        .AddSingleton<AppSettings, AppSettings>()
        .AddSingleton(appSettings)
        .AddScoped<IMessageService, MessageService>()
        .AddScoped<IRabbitMQService, RabbitMQService>()
        .AddScoped<ISendInBlueService, SendInBlueService>()
        .AddScoped<ISendGridService, SendGridService>()
        .AddScoped<IMandrillService, MandrillService>()
        .AddSingleton<Runner>()
        .AddHostedService<NotificationHostedService>()
    );


await host.RunConsoleAsync();




