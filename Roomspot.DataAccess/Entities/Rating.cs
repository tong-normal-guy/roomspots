using System;
using System.Collections.Generic;

namespace Roomspot.DataAccess.Entities;

public partial class Rating
{
    public Guid Id { get; set; }

    public string Status { get; set; } = null!;

    public long Level { get; set; }

    public string? Content { get; set; }

    public Guid FromUser { get; set; }

    public Guid ToUser { get; set; }

    public DateTime CreateAt { get; set; }

    public Guid? ByPost { get; set; }

    public virtual Post? ByPostNavigation { get; set; }
}
