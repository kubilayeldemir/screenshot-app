using System;
using Zcreenshot.Api.Models;

namespace Zcreenshot.Api.Repositories
{
    public interface IScreenshotRepository
    {
        public Screenshot GetById(Guid guid);
        public Screenshot Save(Screenshot screenshot);
        public Screenshot Update(Screenshot screenshot);
    }
}