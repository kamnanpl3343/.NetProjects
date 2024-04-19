using testkamna.Models.Common;

namespace testkamna.Models
{
    public class CommentsViewModel : CommonModel<CommentsViewModel>
    {
        public int CommentId { get; set; }
        public int? LeadId { get; set; }
        public string? CommentText { get; set; }

        public DateTime? CommentDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
