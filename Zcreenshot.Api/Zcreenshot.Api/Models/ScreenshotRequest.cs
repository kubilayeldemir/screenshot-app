using System;

namespace Zcreenshot.Api.Models
{
    public class ScreenshotRequest
    {
        public Guid ScreenshotId { get; set; }
        public string WebsiteURL { get; set; }

        public ScreenshotRequest(string websiteUrl)
        {
            WebsiteURL = websiteUrl;
        }
    }
}