using Alumni.Web.Response;

namespace Alumni.Web.Services
{
	public class FileService : IFileService
	{

		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly string _rootPath;
		public FileService(IWebHostEnvironment webHostEnvironment)
		{
			_webHostEnvironment = webHostEnvironment;
			_rootPath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot");
		}

		public async Task<ResponseModel> Upload(string filePath, Stream fileStream)
		{
			try
			{
				using (var stream = new FileStream(Path.Combine(_rootPath, filePath), FileMode.Create, FileAccess.Write))
				{
					MemoryStream memoryStream = new ();
					await fileStream.CopyToAsync(memoryStream);
					memoryStream.WriteTo(stream);
				}

				return new () { isSuccess = true };
			}
			catch (Exception ex)
			{
				return new () { isSuccess = false, Message = ex.Message };
			}

		}

		public ResponseModel Delete(string filePath)
		{
			try
			{
				if (File.Exists(Path.Combine(_rootPath, filePath)))
				{
					File.Delete(Path.Combine(_rootPath, filePath));
				}

				return new() { isSuccess = true };
			}
			catch (Exception ex)
			{
				return new() { isSuccess = false, Message = ex.Message };
			}
		}
	}

	public interface IFileService
	{
		Task<ResponseModel> Upload(string filePath, Stream fileStream);
		ResponseModel Delete(string filePath);
	}
}
