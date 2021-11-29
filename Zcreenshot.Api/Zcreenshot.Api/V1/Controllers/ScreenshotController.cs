using System;
using Microsoft.AspNetCore.Mvc;
using Zcreenshot.Api.Models;
using Zcreenshot.Api.Services;
using Zcreenshot.Api.V1.Models.RequestModels;
using Zcreenshot.Api.V1.Models.ResponseModels;

namespace Zcreenshot.Api.V1.Controllers
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

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_screenshotService.GetScreenshotById(id));
        }

        [HttpPost("request-screenshot")]
        public IActionResult RequestScreenshot(ScreenshotRequestRequestModel model)
        {
            var screenshotToTake = model.ToModel();
            var screenshotId = _screenshotService.SaveAndPushScreenshotRequest(screenshotToTake);
            var res = new ScreenshotRequestResponseModel();
            res.ScreenshotId = screenshotId;
            res.Status = ScreenshotStatus.WaitingForScreenshot;
            return Accepted(res);
        }
    }
}