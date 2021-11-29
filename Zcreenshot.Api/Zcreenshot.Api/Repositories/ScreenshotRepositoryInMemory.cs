using System;
using System.Collections.Generic;
using Zcreenshot.Api.Models;

namespace Zcreenshot.Api.Repositories
{
    public class ScreenshotRepositoryInMemory : IScreenshotRepository
    {
        private Dictionary<Guid, Screenshot> inMemoryDatabase;

        public ScreenshotRepositoryInMemory()
        {
            inMemoryDatabase = new Dictionary<Guid, Screenshot>();
        }

        public Screenshot GetById(Guid guid)
        {
            return inMemoryDatabase[guid];
        }

        public Screenshot Save(Screenshot screenshot)
        {
            inMemoryDatabase[screenshot.ScreenshotId] = screenshot;
            return screenshot;
        }

        public Screenshot Update(Screenshot screenshot)
        {
            inMemoryDatabase[screenshot.ScreenshotId] = screenshot;
            return screenshot;
        }
    }
}