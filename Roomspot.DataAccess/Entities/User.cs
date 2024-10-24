using System;
using System.Collections.Generic;

namespace Roomspot.DataAccess.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string Status { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Image { get; set; }

    public long? Pets { get; set; }

    public bool? IsMarried { get; set; }

    public string? About { get; set; }

    public string Cccd { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public virtual ICollection<Owner> Owners { get; set; } = new List<Owner>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Renter> Renters { get; set; } = new List<Renter>();
}
