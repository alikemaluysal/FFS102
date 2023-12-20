using System;
using System.Collections.Generic;

namespace SchoolProject.Entities;

public partial class Instructor
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
