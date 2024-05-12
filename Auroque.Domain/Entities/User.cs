using System;
using System.Collections.Generic;

namespace Auroque.Domain.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Observation { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Login { get; set; }

    public string? PasswordHash { get; set; }

    public DateTime LastLogin { get; set; }

    public int? LoginFailures { get; set; }

    public bool? IsActive { get; set; }

    public string? RoleName { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? LastUpdatedBy { get; set; }

    public string? CreatedBy { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
