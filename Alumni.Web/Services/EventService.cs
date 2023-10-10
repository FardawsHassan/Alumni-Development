using Alumni.Web.Data;
using Alumni.Web.Models;
using Alumni.Web.Response;
using Microsoft.EntityFrameworkCore;

namespace Alumni.Web.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetEvents();
        Task<Event> AddPost(Event _event);
        Task<Event> UpdatePost(int id, Event _event);
        Task<ResponseModel> DeletePost(int id);
    }

    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;

        public EventService(ApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<List<Event>> GetEvents()
        {
            try
            {
                return await _context.Events.Include(x => x.Photo).ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<Event> AddPost(Event _event)
        {
            try
            {
                _event.PublishedDate = DateTime.Now;
                var addedEvent= await _context.Events.AddAsync(_event);
                await _context.SaveChangesAsync();

                _event.Photo.PhotoId = addedEvent.Entity.Photo.PhotoId;
                _event.EventId = addedEvent.Entity.EventId;
                return _event;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Event> UpdatePost(int id, Event model)
        {
            try
            {
                var _event = await _context.Events.FindAsync(id);
                if (_event is not null)
                {
                    _event.Photo.PhotoPath = model.Photo.PhotoPath;
                    _event.Photo.Caption = model.Title;
                    _event.Title = model.Title;
                    _event.Description = model.Description;

                    var updatedEvent= _context.Events.Update(_event);
                    await _context.SaveChangesAsync();

                    return updatedEvent.Entity;
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
                var hasEvent= await _context.Events.FindAsync(id);
                if (hasEvent is not null)
                {
                    _context.Events.Remove(hasEvent);
                    _fileService.Delete(hasEvent.Photo.PhotoPath);
                    await _context.SaveChangesAsync();

                    return new ResponseModel
                    {
                        isSuccess = true,
                        Message = "Event post deleted sucessfully!"
                    };
                }

                return new ResponseModel
                {
                    isSuccess = false,
                    Message = "Event not found!"
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
