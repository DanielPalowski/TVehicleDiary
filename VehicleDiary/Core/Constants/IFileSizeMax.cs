namespace VehicleDiary.Core.Constants
{
    public interface IFileSizeMax
    {
        public const long MAX_FILE_SIZE = 5 * 1024 * 1024; // 5 MB
        public static readonly string[] PERMITTED_EXTENSIONS = 
        [
            ".jpg", ".jpeg", ".png", ".pdf", ".docx", ".xlsx", ".doc", ".txt"
        ];
    }
}
