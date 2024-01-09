using System.ComponentModel.DataAnnotations;

namespace ExampleMVCProject.Entities;

public class Student
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string Phone { get; set; }
    public string Class { get; set; }
}
