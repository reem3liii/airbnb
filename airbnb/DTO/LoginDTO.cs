using System.ComponentModel.DataAnnotations;

namespace airbnb.DTO
{
    public class LoginDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
