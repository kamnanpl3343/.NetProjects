using System;
using System.Collections.Generic;

namespace testkamna.Database;

public partial class FollowUp
{
    public int FollowUpId { get; set; }

    public int? LeadId { get; set; }

    public DateTime? FollowUpDate { get; set; }

    public string? Notes { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Lead? Lead { get; set; }
}
