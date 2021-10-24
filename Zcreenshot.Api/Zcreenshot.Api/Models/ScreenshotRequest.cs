namespace Zcreenshot.Api.Models
{
    public class ScreenshotRequest
    {
        public string WebsiteURL { get; set; }

        public ScreenshotRequest(string websiteUrl)
        {
            WebsiteURL = websiteUrl;
        }
    }
}