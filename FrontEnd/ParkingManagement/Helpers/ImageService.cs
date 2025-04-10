namespace ParkingManagement.Helpers
{
    public class ImageService
    {
        private static readonly string _baseUrl = "https://localhost:7113/files/";

        public static string GetParkingImageUrl(string photo)
        {
            return $"{_baseUrl}ParkingsImages/{photo}";
        }

        public static string GetUserImageUrl(string photo)
        {
            return $"{_baseUrl}UsersImages/{photo}";
        }

        public static string GetUserCoverUrl(string photo)
        {
            return $"{_baseUrl}UsersCovers/{photo}";
        }
    }
}
