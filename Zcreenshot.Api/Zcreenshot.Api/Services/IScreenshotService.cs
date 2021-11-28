using System;
using Zcreenshot.Api.Models;

namespace Zcreenshot.Api.Services
{
    public interface IScreenshotService
    {
        public Guid SaveScreenshotRequest(ScreenshotRequest screenshotRequest);

        public void SaveTakenScreenshot(ScreenshotCreated screenshotCreated);

        public Guid SaveAndPushScreenshotRequest(ScreenshotRequest request);
    }
}