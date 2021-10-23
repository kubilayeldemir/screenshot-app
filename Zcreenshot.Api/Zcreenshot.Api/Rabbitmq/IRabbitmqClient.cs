namespace Zcreenshot.Api.Rabbitmq
{
    public interface IRabbitmqClient
    {
        void Push<T>(string queue, T model);
    }
}