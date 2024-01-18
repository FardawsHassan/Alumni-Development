namespace Alumni.Web.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public Photo? Photo { get; set; }
    }
}
