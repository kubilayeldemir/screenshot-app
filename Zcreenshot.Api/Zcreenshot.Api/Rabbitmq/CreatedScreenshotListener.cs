using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Zcreenshot.Api.Models;
using Zcreenshot.Api.Services;

namespace Zcreenshot.Api.Rabbitmq
{
    public class CreatedScreenshotListener : IHostedService
    {
        private readonly IRabbitmqConnection _connection;
        private readonly IScreenshotService _screenshotService;
        private IModel channel;

        public CreatedScreenshotListener(IRabbitmqConnection connection, IScreenshotService screenshotService)
        {
            _connection = connection;
            _screenshotService = screenshotService;
            CreateChannel();
        }

        private void CreateChannel()
        {
            channel = _connection.GetRabbitMqConnection().CreateModel();
        }

        public void Register()
        {
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                string bodyAsString = Encoding.UTF8.GetString(ea.Body.ToArray());
                var screenshotCreated =
                    JsonConvert.DeserializeObject<ScreenshotCreated>(Encoding.UTF8.GetString(ea.Body.ToArray()));
                _screenshotService.SaveTakenScreenshot(screenshotCreated);
                Console.WriteLine($"Received Taken Screenshot {screenshotCreated.ScreenshotId}");
            };
            channel.BasicConsume("screenshot-created", true, consumer);
        }

        public void Deregister()
        {
            _connection.GetRabbitMqConnection().Close();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Register();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Deregister();
            return Task.CompletedTask;
        }
    }
}