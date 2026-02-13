using System.ComponentModel.DataAnnotations;

namespace Kabnab_Board.Application.DTOs;

public class RegisterDTO
{
    [EmailAddress]
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Fullname { get; set; }

}

public class LoginDTO
{
    [EmailAddress]
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}