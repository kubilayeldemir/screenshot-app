using System;
using System.IO;
using System.Net;
using System.Net.Http;
using FluentValidation;
using Zcreenshot.Api.V1.Models.RequestModels;

namespace Zcreenshot.Api.V1.Validations
{
    public class ScreenshotRequestRequestValidation :AbstractValidator<ScreenshotRequestRequestModel>
    {
        public ScreenshotRequestRequestValidation()
        {
            RuleFor(x => x.WebsiteURL)
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .When(x => !string.IsNullOrEmpty(x.WebsiteURL))
                .OnFailure(x => throw new HttpRequestException($"Website URL: {x.WebsiteURL} is not a valid URL",null,HttpStatusCode.BadRequest));
        }
    }
}