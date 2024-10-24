using System;
using System.Collections.Generic;

namespace Roomspot.DataAccess.Entities;

public partial class Utility
{
    public Guid Id { get; set; }

    public string Status { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<PostUtility> PostUtilities { get; set; } = new List<PostUtility>();
}
