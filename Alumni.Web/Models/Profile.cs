namespace Alumni.Web.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? FullName { get; set; }
        public string? NickName { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? PhotoPath { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public string? Email { get; set; }
        public string? GithubUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? CurrentAddress { get; set; }
        public string? PermanantAddress { get; set; }

        public int? Session { get; set; }
        public int? Roll { get; set; }
        public string? Batches { get; set; }
        public bool? isCurrentStudent { get; set; }
        public bool? isRenowned { get; set; }
        public bool isApproved { get; set; }

        public List<PostGrad> PostGrads { get; set; }
        public List<Business> Businesses { get; set; }
        public List<GovtJob> GovtJobs { get; set; }
        public List<PrivateJob> PrivateJobs { get; set; }
        public Freelance? Freelance { get; set; }
        public bool? isUnemployeed { get; set; }
    }
}
