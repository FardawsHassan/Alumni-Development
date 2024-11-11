using Alumni.Web.Data;
using Alumni.Web.Models;
using Alumni.Web.Response;
using Microsoft.EntityFrameworkCore;

namespace Alumni.Web.Services
{
    public interface INoticeService
    {
        Task<List<Notice>> GetNotices();
        Task<Notice> AddPost(Notice notice);
        Task<Notice> UpdatePost(int id, Notice notice);
        Task<ResponseModel> DeletePost(int id);
    }

    public class NoticeService : INoticeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;

        public NoticeService(ApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<List<Notice>> GetNotices()
        {
            try
            {
                return await _context.Notices.Include(x => x.Photo).ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<Notice> AddPost(Notice notice)
        {
            try
            {
                notice.PublishedDate = DateTime.Now;
                var addedNotice = await _context.Notices.AddAsync(notice);
                await _context.SaveChangesAsync();

                notice.Photo.PhotoId = addedNotice.Entity.Photo.PhotoId;
                notice.NoticeId = addedNotice.Entity.NoticeId;
                return notice;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Notice> UpdatePost(int id, Notice model)
        {
            try
            {
                var notice = await _context.Notices.FindAsync(id);
                if (notice is not null)
                {
                    notice.Photo.PhotoPath = model.Photo.PhotoPath;
                    notice.Photo.Caption = model.Title;
                    notice.Title = model.Title;
                    notice.Description = model.Description;

                    var updatedNotice= _context.Notices.Update(notice);
                    await _context.SaveChangesAsync();

                    return updatedNotice.Entity;
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
                var hasNotice= await _context.Notices.FindAsync(id);
                if (hasNotice is not null)
                {
                    _context.Notices.Remove(hasNotice);
                    _fileService.Delete(hasNotice.Photo.PhotoPath);
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
