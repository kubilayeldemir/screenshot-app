using System;
using System.Collections.Generic;
using Zcreenshot.Api.Models;
using Zcreenshot.Api.Repositories;

namespace Zcreenshot.Api.Services
{
    public class ScreenshotService : IScreenshotService
    {
        private readonly IScreenshotQueueService _screenshotQueueService;
        private readonly IScreenshotRepository _screenshotRepository;

        public ScreenshotService(IScreenshotQueueService screenshotQueueService,
            IScreenshotRepository screenshotRepository)
        {
            _screenshotQueueService = screenshotQueueService;
            _screenshotRepository = screenshotRepository;
        }

        public Guid SaveAndPushScreenshotRequest(ScreenshotRequest request)
        {
            var id = SaveScreenshotRequest(request);
            request.ScreenshotId = id;
            _screenshotQueueService.PushScreenshotRequest(request);
            return id;
        }

        public Screenshot GetScreenshotById(Guid id)
        {
            return _screenshotRepository.GetById(id);
        }

        public Guid SaveScreenshotRequest(ScreenshotRequest screenshotRequest)
        {
            Screenshot sc = new Screenshot();
            sc.ScreenshotId = Guid.NewGuid();
            sc.ImageBase64 = screenshotRequest.WebsiteURL;
            sc.Status = ScreenshotStatus.WaitingForScreenshot;
            _screenshotRepository.Save(sc);
            return sc.ScreenshotId;
        }

        public void SaveTakenScreenshot(ScreenshotCreated screenshotCreated)
        {
            if (_screenshotRepository.GetById(new Guid(screenshotCreated.ScreenshotId)) == null)
            {
                throw new KeyNotFoundException($"Screenshot with id:{screenshotCreated.ScreenshotId} not found");
            }

            _screenshotRepository.Save(
                new Screenshot(
                    new Guid(screenshotCreated.ScreenshotId),
                    screenshotCreated.ImageBase64,
                    ScreenshotStatus.ScreenshotTaken));
        }
    }
}