using System;
using System.Collections.Generic;

namespace Roomspot.DataAccess.Entities;

public partial class ChatBox
{
    public Guid Id { get; set; }

    public string Status { get; set; } = null!;

    public Guid User1 { get; set; }

    public Guid User2 { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();
}
