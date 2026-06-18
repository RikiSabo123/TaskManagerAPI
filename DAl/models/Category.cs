using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class Category
{
    public int CategoryId { get; set; }

    public int UserCode { get; set; }

    public string CategoryName { get; set; } = null!;

    public string Color { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual User UserCodeNavigation { get; set; } = null!;
}
