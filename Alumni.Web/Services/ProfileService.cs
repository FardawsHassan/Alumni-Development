using Alumni.Web.Data;
using Alumni.Web.Models;
using Alumni.Web.Response;
using Microsoft.EntityFrameworkCore;

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

                if(profile is not null)
                {
                    return profile;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ResponseModel> UpdateProfile(int id, Profile profile)
        {
            try
            {
                var userProfile = await _context.Profiles.FirstOrDefaultAsync(x => x.Id == id);

                if (userProfile is not null)
                {
                    userProfile.FullName = profile.FullName;
                    userProfile.NickName = profile.NickName;
                    userProfile.Gender = profile.Gender;
                    userProfile.BirthDate = profile.BirthDate;
                    userProfile.PhotoPath = profile.PhotoPath;
                    userProfile.CurrentAddress = profile.CurrentAddress;
                    userProfile.PermanantAddress = profile.PermanantAddress;
                    userProfile.Email = profile.Email;
                    userProfile.FacebookUrl = profile.FacebookUrl;
                    userProfile.GithubUrl = profile.GithubUrl;
                    userProfile.LinkedInUrl = profile.LinkedInUrl;
                    userProfile.Roll = profile.Roll;
                    userProfile.Batches = profile.Batches;
                    userProfile.Session = profile.Session;
                    userProfile.isCurrentStudent = profile.isCurrentStudent;
                    userProfile.isRenowned = profile.isRenowned;
                    userProfile.isApproved = profile.isApproved;
                    
                    if(userProfile.Freelance is null)
                    {
                        var freeLance = new Freelance
                        {
                            ProfileId = userProfile.Id,
                            WorkingFields = profile.Freelance.WorkingFields,
                            StartDate = profile.Freelance.StartDate,
                            EndDate = profile.Freelance.EndDate,
                        };
                        userProfile.Freelance = freeLance;
                    }
                    else
                    {
                        userProfile.Freelance.WorkingFields = profile.Freelance.WorkingFields;
                        userProfile.Freelance.StartDate = profile.Freelance.StartDate;
                        userProfile.Freelance.EndDate = profile.Freelance.EndDate;
                    }

                    if (userProfile.PhoneNumbers is null)
                    {
                        userProfile.PhoneNumbers = profile.PhoneNumbers.Select(x => new PhoneNumber
                        {
                            ProfileId = userProfile.Id,
                            Phone_Number = x.Phone_Number
                        }).ToList();
                    }
                    else
                    {
                        var phoneNumbers = new List<PhoneNumber>();
                        var existingPhoneNumbers =  userProfile.PhoneNumbers.Where(x => profile.PhoneNumbers.Any(pn => pn.PhoneId == x.PhoneId));
                        foreach(var phoneNumber in profile.PhoneNumbers)
                        {
                            var hasPhoneNumber = existingPhoneNumbers.FirstOrDefault(p => p.PhoneId == phoneNumber.PhoneId);
                            if(hasPhoneNumber is not null)
                            {
                                hasPhoneNumber.Phone_Number = phoneNumber.Phone_Number;
                                phoneNumbers.Add(hasPhoneNumber);
                            }
                            else
                            {
                                phoneNumbers.Add(new PhoneNumber
                                {
                                    Phone_Number = phoneNumber.Phone_Number,
                                });
                            }
                        }
                        userProfile.PhoneNumbers = phoneNumbers;
                    }

                    if(userProfile.PostGrads is null)
                    {
                        userProfile.PostGrads = profile.PostGrads.Select(x => new PostGrad
                        {
                            ProfileId = x.ProfileId,
                            PostGradField = x.PostGradField,
                            PostGradDegree = x.PostGradDegree,
                            PostGradUniversity = x.PostGradUniversity,
                        }).ToList();
                    }
                    else
                    {
                        var postGraduations = new List<PostGrad>();
                        var existingPostGraduations = userProfile.PostGrads.Where(x => profile.PostGrads.Any(pg => pg.PostGradId == x.PostGradId));
                        foreach (var postGraduation in profile.PostGrads)
                        {
                            var hasPostGraduation = existingPostGraduations.FirstOrDefault(pg => pg.PostGradId == postGraduation.PostGradId);
                            if (hasPostGraduation is not null)
                            {
                                hasPostGraduation.PostGradField = postGraduation.PostGradField;
                                hasPostGraduation.PostGradDegree = postGraduation.PostGradDegree;
                                hasPostGraduation.PostGradUniversity = postGraduation.PostGradUniversity;
                                postGraduations.Add(hasPostGraduation);
                            }
                            else
                            {
                                postGraduations.Add(new PostGrad
                                {
                                    PostGradField = postGraduation.PostGradField,
                                    PostGradDegree = postGraduation.PostGradDegree,
                                    PostGradUniversity = postGraduation.PostGradUniversity
                                });
                            }
                        }
                        userProfile.PostGrads = postGraduations;
                    }

                    if(userProfile.Businesses is null)
                    {
                        userProfile.Businesses = profile.Businesses.Select(x => new Business
                        {
                            ProfileId = userProfile.Id,
                            BusinessType = x.BusinessType,
                            StartDate = x.StartDate,
                            EndDate = x.EndDate,

                        }).ToList();
                    }
                    else
                    {
                        var businesses = new List<Business>();
                        var existingBusinesses = userProfile.Businesses.Where(x => profile.Businesses.Any(b => b.BusinessId == x.BusinessId));
                        foreach (var business in profile.Businesses)
                        {
                            var hasBusiness = existingBusinesses.FirstOrDefault(b => b.BusinessId == business.BusinessId);
                            if (hasBusiness is not null)
                            {
                                hasBusiness.BusinessType = business.BusinessType;
                                hasBusiness.StartDate = business.StartDate;
                                hasBusiness.EndDate = business.EndDate;
                                businesses.Add(hasBusiness);
                            }
                            else
                            {
                                businesses.Add(new Business
                                {
                                    BusinessType = business.BusinessType,
                                    StartDate = business.StartDate,
                                    EndDate = business.EndDate
                                });
                            }
                        }
                        userProfile.Businesses = businesses;
                    }

                    if(userProfile.GovtJobs is null)
                    {
                        userProfile.GovtJobs = profile.GovtJobs.Select(x => new GovtJob
                        {
                            ProfileId = userProfile.Id,
                            Designation = x.Designation,
                            Organization = x.Organization,
                            StartDate = x.StartDate,
                            EndDate = x.EndDate,

                        }).ToList();
                    }
                    else
                    {
                        var governmentJobs = new List<GovtJob>();
                        var existingGovernmentJobs = userProfile.GovtJobs.Where(x => profile.GovtJobs.Any(g => g.GovtJobId == x.GovtJobId));
                        foreach (var governmentJob in profile.GovtJobs)
                        {
                            var hasGovernmentJob = existingGovernmentJobs.FirstOrDefault(g => g.GovtJobId == governmentJob.GovtJobId);
                            if (hasGovernmentJob is not null)
                            {
                                hasGovernmentJob.Designation = governmentJob.Designation;
                                hasGovernmentJob.Organization = governmentJob.Organization;
                                hasGovernmentJob.StartDate = governmentJob.StartDate;
                                hasGovernmentJob.EndDate = governmentJob.EndDate;
                                governmentJobs.Add(hasGovernmentJob);
                            }
                            else
                            {
                                governmentJobs.Add(new GovtJob
                                {
                                    Designation = governmentJob.Designation,
                                    Organization = governmentJob.Organization,
                                    StartDate = governmentJob.StartDate,
                                    EndDate = governmentJob.EndDate,
                                });
                            }
                        }
                        userProfile.GovtJobs = governmentJobs;
                    }

                    if (userProfile.PrivateJobs is null)
                    {
                        userProfile.PrivateJobs = profile.PrivateJobs.Select(x => new PrivateJob
                        {
                            ProfileId = userProfile.Id,
                            Designation = x.Designation,
                            Organization = x.Organization,
                            StartDate = x.StartDate,
                            EndDate = x.EndDate,

                        }).ToList();
                    }
                    else
                    {
                        var privateJobs = new List<PrivateJob>();
                        var existingPrivateJobs = userProfile.PrivateJobs.Where(x => profile.PrivateJobs.Any(p => p.PrivateJobId == x.PrivateJobId));
                        foreach (var privateJob in profile.PrivateJobs)
                        {
                            var hasPrivateJob = existingPrivateJobs.FirstOrDefault(p => p.PrivateJobId == privateJob.PrivateJobId);
                            if (hasPrivateJob is not null)
                            {
                                hasPrivateJob.Designation = privateJob.Designation;
                                hasPrivateJob.Organization = privateJob.Organization;
                                hasPrivateJob.StartDate = privateJob.StartDate;
                                hasPrivateJob.EndDate = privateJob.EndDate;
                                privateJobs.Add(hasPrivateJob);
                            }
                            else
                            {
                                privateJobs.Add(new PrivateJob
                                {
                                    Designation = privateJob.Designation,
                                    Organization = privateJob.Organization,
                                    StartDate = privateJob.StartDate,
                                    EndDate = privateJob.EndDate,
                                });
                            }
                        }
                        userProfile.PrivateJobs = privateJobs;
                    }

                    _context.Profiles.Update(userProfile);
                    await _context.SaveChangesAsync();

                    return new ResponseModel
                    {
                        isSuccess = true,
                        Message = "Profile updated sucessfully!"
                    };
                }

                return new ResponseModel
                {
                    isSuccess = false,
                    Message = "User not found!"
                };
            }
            catch(Exception ex)
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
        Task<ResponseModel> UpdateProfile(int id, Profile profile);
    }
}
