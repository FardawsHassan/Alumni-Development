namespace Alumni.Web.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
