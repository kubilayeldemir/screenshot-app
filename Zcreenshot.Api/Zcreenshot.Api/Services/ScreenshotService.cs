using System;
using Zcreenshot.Api.Models;
using Zcreenshot.Api.Repositories;

namespace Zcreenshot.Api.Services
{
    public class ScreenshotService : IScreenshotService
    {
        private readonly IScreenshotQueueService _screenshotQueueService;
        private readonly IScreenshotRepository _screenshotRepository;

        public ScreenshotService(IScreenshotQueueService screenshotQueueService, IScreenshotRepository screenshotRepository)
        {
            _screenshotQueueService = screenshotQueueService;
            _screenshotRepository = screenshotRepository;
        }

        public Guid SaveScreenshotRequest(ScreenshotRequest screenshotRequest)
        {
            Screenshot sc = new Screenshot(Guid.NewGuid(),null,ScreenshotStatus.WaitingForScreenshotRequest);
            
            return sc.ScreenshotId;
        }

        public void SaveTakenScreenshot(ScreenshotCreated screenshotCreated)
        {
            throw new NotImplementedException();
        }

        public Guid SaveAndPushScreenshotRequest(ScreenshotRequest request)
        {
            _screenshotQueueService.PushScreenshotRequest(request);
            var id = SaveScreenshotRequest(request);
            return id;
        }
    }
}