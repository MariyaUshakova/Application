using System;

namespace Application.Services.Model
{
    public class UserSetting
    {
        public Guid UserId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}