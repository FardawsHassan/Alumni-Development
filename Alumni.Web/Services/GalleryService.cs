using Alumni.Web.Data;
using Alumni.Web.Models;
using Alumni.Web.Response;
using Microsoft.EntityFrameworkCore;

namespace Alumni.Web.Services
{
    public interface IGalleryService
    {
        Task<List<PhotoDto>> GetPhotos();
        Task<PhotoDto> AddPhoto(PhotoDto photo);
        Task<PhotoDto> UpdatePhoto(int id, PhotoDto photo);
        Task<ResponseModel> DeletePhoto(int id);
    }

    public class GalleryService : IGalleryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;

        public GalleryService(ApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<List<PhotoDto>> GetPhotos()
        {
            try
            {
                var photos = await _context.Photos.ToListAsync();
                return photos.Select(x => 
                    new PhotoDto {
                        PhotoId = x.PhotoId,
                        ActivityId = x.ActivityId,
                        EventId = x.EventId,
                        NoticeId = x.NoticeId,
                        Caption = x.Caption,
                        PhotoPath = x.PhotoPath,
                        UploadDate = x.UploadDate
                    }
                ).ToList();
            }
            catch
            {
                return null;
            }
        }

        public async Task<PhotoDto> AddPhoto(PhotoDto photoDto)
        {
            try
            {
                Photo photo = new Photo()
                {
                    PhotoPath = photoDto.PhotoPath,
                    Caption = photoDto.Caption,
                    UploadDate = DateTime.Now,
                };
                var addedPhoto = await _context.Photos.AddAsync(photo);
                await _context.SaveChangesAsync();

                photoDto.PhotoId = addedPhoto.Entity.PhotoId;
                return photoDto;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<PhotoDto> UpdatePhoto(int id, PhotoDto model)
        {
            try
            {
                var photo = await _context.Photos.FindAsync(id);
                if (photo is not null)
                {
                    photo.PhotoPath = model.PhotoPath;
                    photo.Caption = model.Caption;

                    var updatedPhoto = _context.Photos.Update(photo);
                    await _context.SaveChangesAsync();

                    return new PhotoDto { 
                        UploadDate = updatedPhoto.Entity.UploadDate,
                        PhotoPath = updatedPhoto.Entity.PhotoPath,
                        Caption = updatedPhoto.Entity.Caption,
                        PhotoId = updatedPhoto.Entity.PhotoId,
                        FileStream = model.FileStream
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ResponseModel> DeletePhoto(int id)
        {
            try
            {
                var hasPhoto = await _context.Photos.FindAsync(id);
                if (hasPhoto is not null)
                {
                    _context.Photos.Remove(hasPhoto);
                    _fileService.Delete(hasPhoto.PhotoPath);
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
