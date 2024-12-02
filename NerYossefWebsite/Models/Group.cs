using System;
using System.Collections.Generic;

namespace NerYossefWebsite.Models;

public partial class Group
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public virtual ICollection<GroupMember> GroupMembers { get; set; } = new List<GroupMember>();
}
