using System;
using System.Collections.Generic;

namespace Roomspot.DataAccess.Entities;

public partial class Plan
{
    public Guid Id { get; set; }

    public string Status { get; set; } = null!;

    public string Name { get; set; } = null!;

    public TimeOnly PostDuration { get; set; }

    public long PostNumber { get; set; }

    public double Price { get; set; }

    public virtual ICollection<OwnerPlan> OwnerPlans { get; set; } = new List<OwnerPlan>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
