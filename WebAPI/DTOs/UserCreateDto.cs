using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.DTOs;

public class UserCreateDto
{
    [MinLength(5)]
    [Required]
    public string FirstName { get; set; }
    [MinLength(3)]
    public string LastName { get; set; }
    public string Email { get; set; }
}
