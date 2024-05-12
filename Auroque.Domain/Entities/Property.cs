using System;
using System.Collections.Generic;

namespace Auroque.Domain.Entities;

public partial class Property
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Cnpj { get; set; }

    public string? TradeName { get; set; }

    public string? Location { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? LastUpdatedBy { get; set; }

    public string? CreatedBy { get; set; }
}
