using System;
using System.Collections.Generic;

namespace Roomspot.DataAccess.Entities;

public partial class Post
{
    public Guid Id { get; set; }

    public string Status { get; set; } = null!;

    public Guid UserId { get; set; }

    public Guid PlanId { get; set; }

    public DateTime CreateAt { get; set; }

    public string? Content { get; set; }

    public Guid AddressId { get; set; }

    public string Images { get; set; } = null!;

    public double Price { get; set; }

    public string? Type { get; set; }

    public double? Square { get; set; }

    public long? SleepRoom { get; set; }

    public long? WaterClose { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual Plan Plan { get; set; } = null!;

    public virtual ICollection<PostUtility> PostUtilities { get; set; } = new List<PostUtility>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual User User { get; set; } = null!;
}
