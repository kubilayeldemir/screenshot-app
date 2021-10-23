using System;
using RabbitMQ.Client;

namespace Zcreenshot.Api.Rabbitmq
{
    public class RabbitmqConnection : IRabbitmqConnection
    {
        private IConnection connection;
        
        public RabbitmqConnection()
        {
            var factory = new ConnectionFactory() { Uri = new Uri(Environment.GetEnvironmentVariable("RABBITMQURI")) };
            connection = factory.CreateConnection();
        }

        public IConnection GetRabbitMqConnection()
        {
            return connection;
        }


    }
}