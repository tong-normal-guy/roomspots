using System;
using System.Collections.Generic;

namespace Roomspot.DataAccess.Entities;

public partial class Chat
{
    public Guid Id { get; set; }

    public Guid Status { get; set; }

    public string Message { get; set; } = null!;

    public Guid GroupId { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual ChatBox Group { get; set; } = null!;
}
