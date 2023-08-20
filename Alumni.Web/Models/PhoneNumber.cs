using MessagePack;

namespace Alumni.Web.Models
{
    public class PhoneNumber
    {
        public int PhoneId { get; set; }
        public int ProfileId { get; set; }
        public string? Phone_Number { get; set; }
        public Profile Profile { get; set; }
    }
}
