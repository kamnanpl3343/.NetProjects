using System;
using System.Collections.Generic;

namespace testkamna.Database;

public partial class Comment
{
    public int CommentId { get; set; }

    public int? LeadId { get; set; }

    public DateTime? CommentDate { get; set; }

    public string? CommentText { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Lead? Lead { get; set; }
}
