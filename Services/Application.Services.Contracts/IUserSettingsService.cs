using Application.Services.Model;

namespace Application.Services.Contracts
{
    public interface IUserSettingsService
    {
        Task<List<UserSetting>> GetUserSettings();
        Task AddUserSetting(Guid userId, string key, string value);
        Task UpdateUserSetting(Guid userId, string key, string value);
    }
}