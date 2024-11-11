namespace Alumni.Web
{
    public static class AppSettings
    {
        public const string SectionName = "Settings";
        public static Settings Settings { get; set; } = new();
    }

    public class Settings
    {
        public string ConnectionString { get; set; }
        public string DefaultFileStorageContainer { get; set; }
        public string ProfileImageStorageContainer { get; set; }
        public string GalleryImageStorageContainer { get; set; }
        public string NoticeFileStorageContainer { get; set; }
        public string EventImageStorageContainer { get; set; }
        public string ActivityImageStorageContainer { get; set; }
    }
}
