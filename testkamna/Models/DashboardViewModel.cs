namespace testkamna.Models
{
    public class DashboardViewModel
    {
        public string CurrentUser { get; set; }
        public int CompanyId { get; set; }

        public int SelfCreatedLeads { get; set; }
        public int AssignedLeads { get; set; }
        public int TotalLeads { get; set; }
        public int TotalNewLeads { get; set; }

        public LeadsViewModel AssignedLeadsData { get; set; }
        public LeadsViewModel NewLeadsData { get; set; }
    }
}
