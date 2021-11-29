using System;
using Zcreenshot.Api.Models;
using Zcreenshot.Api.Repositories;

namespace Zcreenshot.Api.Services
{
    public class ScreenshotQueueService : IScreenshotQueueService
    {
        private readonly IScreenshotQueueRepository _queueRepository;

        public ScreenshotQueueService(IScreenshotQueueRepository queueRepository)
        {
            _queueRepository = queueRepository;
        }
        public void PushScreenshotRequest(ScreenshotRequest request)
        {
            _queueRepository.PushScreenshotRequestToQueue(request);
        }
    }
}