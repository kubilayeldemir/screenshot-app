using Zcreenshot.Api.Models;

namespace Zcreenshot.Api.V1.Models.RequestModels
{
    public class ScreenshotRequestRequestModel
    {
        public string WebsiteURL { get; set; }

        public ScreenshotRequest ToModel()
        {
            return new ScreenshotRequest(WebsiteURL);
        }
    }
}