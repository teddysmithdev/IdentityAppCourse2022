using Microsoft.AspNetCore.Authorization;

namespace IdentityAppCourse2022.Authorization
{
    public class NicknameRequirement : IAuthorizationRequirement
    {
        public string Name { get; set; }
        public NicknameRequirement(string name)
        {
            Name = name;
        }
    }
}
