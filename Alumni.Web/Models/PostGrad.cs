namespace Alumni.Web.Models
{
    public class PostGrad
    {
        public int PostGradId { get; set; }
        public int ProfileId { get; set; }
        public string? PostGradUniversity { get; set; }
        public string? PostGradDegree { get; set; }
        public string? PostGradField { get; set; }
        public Profile Profile { get; set; }
    }
}
