using System.ComponentModel.DataAnnotations;

namespace IdentityAppCourse2022.ViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
