namespace Alumni.Web.Models
{
    public class Notice
    {
        public int NoticeId { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
