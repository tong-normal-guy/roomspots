using System;
using System.Collections.Generic;

namespace Roomspot.DataAccess.Entities;

public partial class OwnerPlan
{
    public Guid Id { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly CreateAt { get; set; }

    public Guid PlanId { get; set; }

    public Guid OwnerId { get; set; }

    public virtual Owner Owner { get; set; } = null!;

    public virtual Plan Plan { get; set; } = null!;
}
