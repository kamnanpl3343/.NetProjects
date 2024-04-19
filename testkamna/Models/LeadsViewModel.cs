using System.ComponentModel.DataAnnotations;
using testkamna.Models.Common;

namespace testkamna.Models
{
    public class LeadsViewModel : CommonModel<LeadsViewModel>
    {
        public int LeadId { get; set; }

        [Required, StringLength(30, MinimumLength = 3, ErrorMessage = "The length must be between 3 and 30 characters.")]
        [RegularExpression(@"^[a-zA-Z\s.-]+$", ErrorMessage = "The name can only contain alphabetic characters and spaces.")]
        public string? ContactName { get; set; }

        [Required, StringLength(30, ErrorMessage = "The address must be less than 30 characters.")]
        public string? Address { get; set; }

        [Required, RegularExpression(@"^9[78]\d{8}$", ErrorMessage = "Please enter a valid mobile phone number.")]
        public string? Phone { get; set; }

        public string? Location { get; set; }
        public string? Flag { get; set; }

        [Required, RegularExpression(@"^[A-Za-z0-9\s.-\/]+$", ErrorMessage = "Invalid company name format. Only alphanumeric characters and spaces are allowed.")]
        public string? CompanyName { get; set; }

        [Required(ErrorMessage = "Please select at least one interest")]
        public string? Interest { get; set; }
        public string? Remark { get; set; }
        [Required, RegularExpression(@"^[a-zA-Z0-9\s!#$&*()._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage ="Invalid Email Format")]
        public string? Email { get; set; }
        public string? UserAssignee { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public int CompanyId { get; set; }
        public DateTime? FollowupDate { get; set; }
        public string? FollowupRemark { get; set; }

        public FollowUpsViewModel? FollowUpData { get; set; }

        public CommentsViewModel? CommentData { get; set; }

        public string type = "";
       
    /*   public string UserAssignee { get; set; }
       public string Status { get; set; }
       public DateTime? CreatedDate { get; set; }
       public string CreatedBy { get; set; }
       public int CompanyId { get; set; }
       public DateTime? FollowupDate { get; set; }
       public string FollowupRemark { get; set; }*/


}
}
