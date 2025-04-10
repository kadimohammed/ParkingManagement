namespace ParkingManagement.Api.Healpers
{
    public interface IFileUpload
    {
        UploadState uploadState { get; set; }
        void UploadImage(IFormFile file, string path);
        bool DeleteImage(string photoName, string path);
    }
}
