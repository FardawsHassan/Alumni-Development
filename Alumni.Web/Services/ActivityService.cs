using Alumni.Web.Data;
using Alumni.Web.Models;
using Alumni.Web.Response;
using Microsoft.EntityFrameworkCore;

namespace Alumni.Web.Services
{
    public interface IActivityService
    {
        Task<List<Activity>> GetActivities();
        Task<Activity> AddPost(Activity activity);
        Task<Activity> UpdatePost(int id, Activity activity);
        Task<ResponseModel> DeletePost(int id);
    }

    public class ActivityService : IActivityService
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;

        public ActivityService(ApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<List<Activity>> GetActivities()
        {
            try
            {
                return await _context.Activities.Include(x => x.Photo).ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<Activity> AddPost(Activity activity)
        {
            try
            {
                activity.PublishedDate = DateTime.Now;
                var addedActivity = await _context.Activities.AddAsync(activity);
                await _context.SaveChangesAsync();

                activity.Photo.PhotoId = addedActivity.Entity.Photo.PhotoId;
                activity.ActivityId = addedActivity.Entity.ActivityId;
                return activity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Activity> UpdatePost(int id, Activity model)
        {
            try
            {
                var activity = await _context.Activities.FindAsync(id);
                if (activity is not null)
                {
                    activity.Photo.PhotoPath = model.Photo.PhotoPath;
                    activity.Photo.Caption = model.Title;
                    activity.Title = model.Title;
                    activity.Description = model.Description;

                    var updatedActivity= _context.Activities.Update(activity);
                    await _context.SaveChangesAsync();

                    return updatedActivity.Entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ResponseModel> DeletePost(int id)
        {
            try
            {
                var hasActivity = await _context.Activities.FindAsync(id);
                if (hasActivity is not null)
                {
                    _context.Activities.Remove(hasActivity);
                    _fileService.Delete(hasActivity.Photo.PhotoPath);
                    await _context.SaveChangesAsync();

                    return new ResponseModel
                    {
                        isSuccess = true,
                        Message = "Activity post deleted sucessfully!"
                    };
                }

                return new ResponseModel
                {
                    isSuccess = false,
                    Message = "Activity not found!"
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
}
