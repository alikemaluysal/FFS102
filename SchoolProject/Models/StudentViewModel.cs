using SchoolProject.Models.Entities;

namespace SchoolProject.Models;

public class StudentViewModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FieldName { get; set; }
    public string Courses { get; set; }
    public string Instructors { get; set; }
}
