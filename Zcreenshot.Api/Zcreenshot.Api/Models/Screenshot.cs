using System;

namespace Zcreenshot.Api.Models
{
    public class Screenshot
    {
        public Guid ScreenshotId { get; set; }
        public string ImageBase64 { get; set; }
        public string Status { get; set; }

        public Screenshot()
        {
        }

        public Screenshot(Guid screenshotId, string imageBase64, string status)
        {
            ScreenshotId = screenshotId;
            ImageBase64 = imageBase64;
            Status = status;
        }
    }
}