using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Zcreenshot.Api.Rabbitmq
{
    public class RabbitmqClient : IRabbitmqClient
    {
        private readonly IRabbitmqConnection _connection;
        private IModel channel;

        public RabbitmqClient(IRabbitmqConnection connection)
        {
            _connection = connection;
            createChannel();
        }

        private void createChannel()
        {
            channel = _connection.GetRabbitMqConnection().CreateModel();
        }

        public void Push<T>(string queue, T model)
        {
            channel.QueueDeclare(queue: queue, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var serializedModel = JsonConvert.SerializeObject(model);
            var body = Encoding.UTF8.GetBytes(serializedModel);

            channel.BasicPublish(exchange: "", routingKey: queue, basicProperties: null, body: body);
            Console.WriteLine("Message Sent {0}", serializedModel);
        }
    }
}