using Alumni.Web.Data;
using Alumni.Web.Models;

namespace Alumni.Web.Services
{

    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _context;
        public ProfileService(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<Profile> GetProfileByEmail(string email)
        {
            try
            {
                Profile profile = new();
                profile = _context.Profiles.FirstOrDefault(p => p.Email == email);
                return profile;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<int?> GetProfileIdByEmail(string email)
        {
            try
            {
                var profile = await GetProfileByEmail(email);
                return profile.Id;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public interface IProfileService
    {
        Task<Profile> GetProfileByEmail(string email);
        Task<int?> GetProfileIdByEmail(string email);
    }
}
