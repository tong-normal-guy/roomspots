using System;
using System.Collections.Generic;

namespace Roomspot.DataAccess.Entities;

public partial class Address
{
    public Guid Id { get; set; }

    public string Street { get; set; } = null!;

    public string District { get; set; } = null!;

    public string? City { get; set; }

    public string State { get; set; } = null!;

    public string HomeNumber { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
