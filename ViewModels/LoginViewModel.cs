using System.ComponentModel.DataAnnotations;

namespace ERPSystem.ViewModels
{
    public class LoginViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
