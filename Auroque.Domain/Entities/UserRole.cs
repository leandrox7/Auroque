using System;
using System.Collections.Generic;

namespace Auroque.Domain.Entities;

public partial class UserRole
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? RoleiD { get; set; }

    public bool? IsEnabled { get; set; }

    public virtual Role? Role { get; set; }

    public virtual User? User { get; set; }
}
