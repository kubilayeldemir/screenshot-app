using Zcreenshot.Api.Models;

namespace Zcreenshot.Api.Services
{
    public interface IScreenshotQueueService
    {
        void PushScreenshotRequest(ScreenshotRequest request);
    }
}