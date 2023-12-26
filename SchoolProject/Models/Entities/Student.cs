using System;
using System.Collections.Generic;

namespace SchoolProject.Models.Entities;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int FieldId { get; set; }

    public virtual Field Field { get; set; } = null!;

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
}
