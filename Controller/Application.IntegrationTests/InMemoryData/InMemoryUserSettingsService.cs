using Application.Services.Contracts;
using Application.Services.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Controller.IntegrationTests.InMemoryData
{
    internal class InMemoryUserSettingsService : IUserSettingsService
    {
        public Task AddUserSetting(Guid userId, string key, string value)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserSetting>> GetUserSettings()
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserSetting(Guid userId, string key, string value)
        {
            throw new NotImplementedException();
        }
    }
}
