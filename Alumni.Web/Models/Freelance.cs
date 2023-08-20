namespace Alumni.Web.Models
{
    public class Freelance
    {
        public int FreelanceId { get; set; }
        public int ProfileId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? WorkingFields { get; set; }
        public Profile Profile { get; set; }
    }
}
