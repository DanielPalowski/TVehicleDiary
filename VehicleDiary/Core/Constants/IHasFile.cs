namespace VehicleDiary.Core.Constants
{
    public interface IHasFile
    {
        string FileName { get; set; }
        string ContentType { get; set; }
        byte[] Data { get; set; }
    }
}
