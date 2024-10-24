using System;
using System.Collections.Generic;

namespace Roomspot.DataAccess.Entities;

public partial class PostUtility
{
    public Guid Id { get; set; }

    public Guid PostId { get; set; }

    public Guid UtilityId { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual Utility Utility { get; set; } = null!;
}
