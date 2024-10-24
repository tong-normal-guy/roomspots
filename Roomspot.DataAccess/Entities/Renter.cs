using System;
using System.Collections.Generic;

namespace Roomspot.DataAccess.Entities;

public partial class Renter
{
    public Guid Id { get; set; }

    public string Status { get; set; } = null!;

    public Guid UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
