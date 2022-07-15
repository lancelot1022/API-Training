
namespace Final_Exam_A.Resources
{
    public class EndPoints
    {
        public const string baseURL = "https://magenicmovies-api.azurewebsites.net";

        public static string PostCinema() => $"{baseURL}/cinemas";

        public static string GetAllCinema() => $"{baseURL}/cinemas";

        public static string GetCinemaById(long Id) => $"{baseURL}/cinemas/{Id}";

        public static string PutCinema(long Id) => $"{baseURL}/cinemas/{Id}";

        public static string DeleteCinema(long Id) => $"{baseURL}/cinemas/{Id}";
    }
}
