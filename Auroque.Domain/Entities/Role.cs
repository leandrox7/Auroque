using System;
using System.Collections.Generic;

namespace Auroque.Domain.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public bool? IsEnabled { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
