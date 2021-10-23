using RabbitMQ.Client;

namespace Zcreenshot.Api.Rabbitmq
{
    public interface IRabbitmqConnection
    {
        IConnection GetRabbitMqConnection();
    }
}