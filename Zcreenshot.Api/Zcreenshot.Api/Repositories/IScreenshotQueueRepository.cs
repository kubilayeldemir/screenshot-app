using Zcreenshot.Api.Models;

namespace Zcreenshot.Api.Repositories
{
    public interface IScreenshotQueueRepository
    {
        bool PushScreenshotRequestToQueue(ScreenshotRequest request);
    }
}