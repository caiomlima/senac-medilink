using System.ComponentModel.DataAnnotations;

namespace Senac.Medilink.Data.Dto.Request.Login;

public class LoginUserRequest
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
