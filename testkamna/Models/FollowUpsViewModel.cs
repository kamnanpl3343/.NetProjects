using testkamna.Models.Common;

namespace testkamna.Models
{
    public class FollowUpsViewModel : CommonModel<FollowUpsViewModel>
    {
        public int FollowUpId { get; set; }
        public int? LeadId { get; set; }
        public string? Notes { get; set; }

        public DateTime? FollowUpDate { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
