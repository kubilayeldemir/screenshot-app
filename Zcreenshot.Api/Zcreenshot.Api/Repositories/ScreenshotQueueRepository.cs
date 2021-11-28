using System;
using Microsoft.Extensions.Logging;
using Zcreenshot.Api.Models;
using Zcreenshot.Api.Rabbitmq;

namespace Zcreenshot.Api.Repositories
{
    public class ScreenshotQueueRepository : IScreenshotQueueRepository
    {
        private readonly IRabbitmqClient _rabbimqClient;
        private readonly ILogger _logger;

        public ScreenshotQueueRepository(IRabbitmqClient rabbimqClient, ILogger<ScreenshotQueueRepository> logger)
        {
            _rabbimqClient = rabbimqClient;
            _logger = logger;
        }

        public bool PushScreenshotRequestToQueue(ScreenshotRequest request)
        {
            _rabbimqClient.Push("take-screenshot", request);
            _logger.LogInformation($"Screenshot Request Added to the Queue. Model: {request.WebsiteURL}");
            return true;
        }
    }
}