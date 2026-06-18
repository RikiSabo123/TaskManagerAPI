using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class User
{
    public int UserCode { get; set; }

    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
