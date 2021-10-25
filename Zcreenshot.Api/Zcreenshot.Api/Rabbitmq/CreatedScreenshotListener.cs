using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Zcreenshot.Api.Models;

namespace Zcreenshot.Api.Rabbitmq
{
    public class CreatedScreenshotListener : IHostedService
    {
        private readonly IRabbitmqConnection _connection;
        private IModel channel;

        public CreatedScreenshotListener(IRabbitmqConnection connection)
        {
            _connection = connection;
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
                var body = JsonConvert.DeserializeObject<ScreenshotCreated>(Encoding.UTF8.GetString(ea.Body.ToArray()));
                //TODO Save screenshot to db
                Console.WriteLine($" [x] Received {body.imageBase64.Substring(0,body.imageBase64.Length < 15 ? body.imageBase64.Length : 15)}");
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