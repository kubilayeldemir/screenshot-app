using Microsoft.AspNetCore.Mvc;
using Zcreenshot.Api.Models;
using Zcreenshot.Api.Repositories;

namespace Zcreenshot.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ScreenshotController : ControllerBase
    {
        private readonly IScreenshotQueueRepository _screenshotQueueRepository;

        public ScreenshotController(IScreenshotQueueRepository screenshotQueueRepository)
        {
            _screenshotQueueRepository = screenshotQueueRepository;
        }

        [HttpPost("request-screenshot")]
        public IActionResult Screenshot(ScreenshotRequest model)
        {
            _screenshotQueueRepository.AddScreenshotRequestToQueue(model);
            return Accepted();
        }
    }
}