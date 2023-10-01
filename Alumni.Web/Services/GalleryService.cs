using Alumni.Web.Data;
using Alumni.Web.Models;
using Alumni.Web.Response;
using Microsoft.EntityFrameworkCore;

namespace Alumni.Web.Services
{
    public interface IGalleryService
    {
        Task<List<Photo>> Gallery();
        Task<Photo> AddGallery(Photo photo);
        Task<Photo> UpdateGallery(int id, Photo photo);
        Task<ResponseModel> DeleteGallery(int id);
    }

    public class GalleryService : IGalleryService
    {
        private readonly ApplicationDbContext _context;
        public GalleryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Photo>> Gallery()
        {
            try
            {
                var photos = await _context.Photos.ToListAsync();
                return photos is not null ? photos : new ();
            }
            catch
            {
                return null;
            }
        }

        public async Task<Photo> AddGallery(Photo photo)
        {
            try
            {
                await _context.Photos.AddAsync(photo);
                await _context.SaveChangesAsync();

                return photo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Photo> UpdateGallery(int id, Photo photo)
        {
            try
            {
                var hasPhoto = await _context.Photos.FindAsync(id);
                if (hasPhoto is not null)
                {
                    hasPhoto.PhotoPath = photo.PhotoPath;
                    hasPhoto.Caption = photo.Caption;

                    _context.Photos.Update(hasPhoto);
                    await _context.SaveChangesAsync();

                    return hasPhoto;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ResponseModel> DeleteGallery(int id)
        {
            try
            {
                var hasPhoto = await _context.Photos.FindAsync(id);
                if (hasPhoto is not null)
                {
                    _context.Photos.Remove(hasPhoto);
                    await _context.SaveChangesAsync();

                    return new ResponseModel
                    {
                        isSuccess = true,
                        Message = "photo deleted sucessfully!"
                    };
                }

                return new ResponseModel
                {
                    isSuccess = false,
                    Message = "photo not found!"
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
