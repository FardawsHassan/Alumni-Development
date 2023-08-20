namespace Alumni.Web.Models
{
    public class GovtJob
    {
        public int GovtJobId { get; set; }
        public int ProfileId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Organization { get; set; } // Name change required
        public string? Designation { get; set; }
        public Profile Profile { get; set; }
    }
}
