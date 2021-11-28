using System;
using Microsoft.AspNetCore.Mvc;
using Zcreenshot.Api.Services;
using Zcreenshot.Api.V1.Models.RequestModels;

namespace Zcreenshot.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ScreenshotController : ControllerBase
    {
        private readonly IScreenshotService _screenshotService;

        public ScreenshotController(IScreenshotService screenshotService)
        {
            _screenshotService = screenshotService;
        }

        [HttpPost("request-screenshot")]
        public IActionResult Screenshot(ScreenshotRequestRequestModel model)
        {
            var screenshotToTake = model.ToModel();
            var screenshotId = _screenshotService.SaveAndPushScreenshotRequest(screenshotToTake);
            return Accepted(model);
        }
    }
}