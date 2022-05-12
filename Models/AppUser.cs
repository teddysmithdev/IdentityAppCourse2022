using Microsoft.AspNetCore.Identity;

namespace IdentityAppCourse2022.Models
{
    public class AppUser : IdentityUser
    {
        public string NickName { get; set; }
    }
}
