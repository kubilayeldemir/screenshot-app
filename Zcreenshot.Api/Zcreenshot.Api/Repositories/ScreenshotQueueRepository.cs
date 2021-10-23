using Zcreenshot.Api.Models;
using Zcreenshot.Api.Rabbitmq;

namespace Zcreenshot.Api.Repositories
{
    public class ScreenshotQueueRepository : IScreenshotQueueRepository
    {
        private readonly IRabbitmqClient _rabbimqClient;
        
        public ScreenshotQueueRepository(IRabbitmqClient rabbimqClient)
        {
            _rabbimqClient = rabbimqClient;
        }

        public bool AddScreenshotRequestToQueue(ScreenshotRequest request)
        {
            _rabbimqClient.Push("take-screenshot",request);
            return true;
        }
    }
}