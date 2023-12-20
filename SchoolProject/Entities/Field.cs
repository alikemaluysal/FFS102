using System;
using System.Collections.Generic;

namespace SchoolProject.Entities;

public partial class Field
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
