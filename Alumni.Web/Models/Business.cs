namespace Alumni.Web.Models
{
    public class Business
    {
        public int BusinessId { get; set; }
        public int ProfileId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? BusinessType { get; set; }
        public Profile Profile { get; set; }
    }
}
