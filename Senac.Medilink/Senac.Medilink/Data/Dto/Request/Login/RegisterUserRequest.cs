using Senac.Medilink.Common;
using System.ComponentModel.DataAnnotations;

namespace Senac.Medilink.Data.Dto.Request.Login;

public class RegisterUserRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(10, ErrorMessage = "A senha precisa ter ao menos 10 caracteres")]
    [MaxLength(200, ErrorMessage = "A senha poder no máximo 200 caracteres")]
    public string Password { get; set; }

    [Required]
    public UserType UserType { get; set; } // isso vem do front, quando seleciona um tipo de cadastro

    [Required]
    [MinLength(1, ErrorMessage = "É necessário informar um nome")]
    [MaxLength(300, ErrorMessage = "Nome pode ter no máximo 300 caracteres")]
    public string Name { get; set; }

    [Required]
    [Length(11, 11, ErrorMessage = "É necessário informar um CPF válido")]
    public string Document { get; set; }
}
