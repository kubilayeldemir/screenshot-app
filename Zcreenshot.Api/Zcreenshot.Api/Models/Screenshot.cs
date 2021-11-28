using System;

namespace Zcreenshot.Api.Models
{
    public class Screenshot
    {
        public Guid ScreenshotId { get; set; }
        public string ImageBase64 { get; set; }
        public ScreenshotStatus Status { get; set; }

        public Screenshot(Guid screenshotId, string imageBase64, ScreenshotStatus status)
        {
            ScreenshotId = screenshotId;
            ImageBase64 = imageBase64;
            Status = status;
        }
    }
}