using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class Task
{
    public int TaskId { get; set; }

    public int? CategoryId { get; set; }

    public string TaskDescription { get; set; } = null!;

    public DateOnly RegistrationDate { get; set; }

    public DateOnly FromDate { get; set; }

    public DateOnly ToDate { get; set; }

    public DateOnly DoneDate { get; set; }

    public string Notes { get; set; } = null!;

    public virtual Category? Category { get; set; }
}
