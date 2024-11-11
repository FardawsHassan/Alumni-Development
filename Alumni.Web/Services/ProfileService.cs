using Alumni.Web.Data;
using Alumni.Web.Models;
using Alumni.Web.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Alumni.Web.Services
{

    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public ProfileService(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        public async Task<List<Profile>> GetProfiles()
        {
            try
            {
                return _context.Profiles.Where(x => x.Email != "admin@gmail.com").ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }
        
        public async Task<List<IdentityUser>> GetModerators()
        {
            try
            {
                var moderators =  await _userManager.GetUsersInRoleAsync("Moderator");
                return moderators.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public async Task<ResponseModel> MakeModerator(Profile profile)
        {
            try
            {
                var user = _userManager.Users.Where(x => x.Email==profile.Email).FirstOrDefault();
                await _userManager.RemoveFromRoleAsync(user, "Member");
                await _userManager.AddToRoleAsync(user, "Moderator");
                return new ResponseModel
                {
                    isSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel { isSuccess = false, Message=ex.Message };
            }
        }
        
        public async Task<ResponseModel> MakeMember(Profile profile)
        {
            try
            {
                var user = _userManager.Users.Where(x => x.Email==profile.Email).FirstOrDefault();
                await _userManager.RemoveFromRoleAsync(user, "Moderator");
                await _userManager.AddToRoleAsync(user, "Member");
                return new ResponseModel
                {
                    isSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel { isSuccess = false, Message=ex.Message };
            }
        }

        public async Task<List<Profile>> GetApprovalPendingProfiles()
        {
            try
            {
                return _context.Profiles.Where(x => x.isApproved != true).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ResponseModel> ApproveProfile(int id)
        {
            try
            {
                var profile = _context.Profiles.Where(x => x.Id == id).FirstOrDefault();
                var user = _userManager.Users.Where(x => x.Email == profile.Email).FirstOrDefault();
                if (profile is not null && user is not null)
                {
                    profile.isApproved = true;
                    _context.Profiles.Update(profile);
                    await _userManager.AddToRoleAsync(user, "Member");
                    await _context.SaveChangesAsync();
                }
                return new()
                {
                    isSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    isSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponseModel> DeleteProfile(int id)
        {
            try
            {
                var profile = _context.Profiles.Where(x => x.Id == id).FirstOrDefault();
                var user = _userManager.Users.Where(x => x.Email == profile.Email).FirstOrDefault();
                if (profile is not null && user is not null)
                {
                    _context.Profiles.Remove(profile);
                    await _userManager.DeleteAsync(user);
                    await _context.SaveChangesAsync();
                }
                return new()
                {
                    isSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    isSuccess = false,
                    Message = ex.Message
                };
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
        Task<List<Profile>> GetProfiles();
        Task<List<Profile>> GetApprovalPendingProfiles();
        Task<ResponseModel> ApproveProfile(int id);
        Task<ResponseModel> DeleteProfile(int id);
        Task<List<IdentityUser>> GetModerators();
        Task<ResponseModel> MakeMember(Profile profile);
        Task<ResponseModel> MakeModerator(Profile profile);
    }
} 
