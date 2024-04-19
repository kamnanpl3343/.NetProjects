using System;
using System.Collections.Generic;

namespace testkamna.Database;

public partial class Lead
{
    public int LeadId { get; set; }

    public string? ContactName { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Location { get; set; }

    public string? CompanyName { get; set; }

    public string? Interest { get; set; }

    public string? Flag { get; set; }

    public string? Remark { get; set; }

    public string? UserAssignee { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int CompanyId { get; set; }

    public string? Email { get; set; }

    public string? CreatedBy { get; set; }

    public virtual ICollection<Comment> Comment { get; set; } = new List<Comment>();

    public virtual ICollection<FollowUp> FollowUp { get; set; } = new List<FollowUp>();
}
