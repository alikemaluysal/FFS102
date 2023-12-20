using System;
using System.Collections.Generic;

namespace SchoolProject.Entities;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int InstructorId { get; set; }

    public virtual Instructor Instructor { get; set; } = null!;

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
}
