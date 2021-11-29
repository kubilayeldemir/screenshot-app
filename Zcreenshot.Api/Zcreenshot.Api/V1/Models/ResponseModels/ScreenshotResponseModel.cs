using System;

namespace Zcreenshot.Api.V1.Models.ResponseModels
{
    public class ScreenshotRequestResponseModel
    {
        public Guid ScreenshotId { get; set; }
        public string Status { get; set; }
    }
}