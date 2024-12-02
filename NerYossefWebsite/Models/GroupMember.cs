using System;
using System.Collections.Generic;

namespace NerYossefWebsite.Models;

public partial class GroupMember
{
    public int GroupMemberId { get; set; }

    public int GroupId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual Group Group { get; set; } = null!;
}
