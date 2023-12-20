using System;
using System.Collections.Generic;

namespace SchoolProject.Entities;

public partial class Note
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateTime IssuedAt { get; set; }

    public double Grade { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
