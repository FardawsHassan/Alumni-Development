using Alumni.Web.Data;
using Alumni.Web.Models;
using Alumni.Web.Response;
using Microsoft.EntityFrameworkCore;

namespace Alumni.Web.Services
{

    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _context;
        public ProfileService(ApplicationDbContext context)
        {
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

        public async Task<Profile> GetProfileById(int id)
        {
            try
            {
                var profile = await _context.Profiles.Where(x => x.Id == id)
                                                     .Include(x => x.Freelance)
                                                     .Include(x => x.PhoneNumbers)
                                                     .Include(x => x.PostGrads)
                                                     .Include(x => x.Businesses)
                                                     .Include(x => x.GovtJobs)
                                                     .Include(x => x.PrivateJobs)
                                                     .FirstOrDefaultAsync();

                return profile;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ResponseModel> UpdateProfile(int id, Profile modifiedProfile)
        {
            try
            {
                _context.Profiles.Update(modifiedProfile);
                await _context.SaveChangesAsync();

                return new ResponseModel
                {
                    isSuccess = true,
                    Message = "Profile updated sucessfully!"
                };
            }
            catch (Exception ex)
            {

                return new ResponseModel
                {
                    isSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }

    public interface IProfileService
    {
        Task<Profile> GetProfileByEmail(string email);
        Task<int?> GetProfileIdByEmail(string email);
        Task<Profile> GetProfileById(int id);
        Task<ResponseModel> UpdateProfile(int id, Profile modifiedProfile);
    }
}
