using Final_Exam_A.DataModels;
using System.Net.Http;
using System.Text;
using Final_Exam_A.Tests.TestData;
using Final_Exam_A.Resources;
using Newtonsoft.Json;

namespace Final_Exam_A.Helpers
{
    public class Cinema_Helper
    {
        public static HttpResponseMessage AddNewCinema(HttpClient client)
        {
            var newCinema = GenerateCinema.newCinema_1();
            var cinemaJSON = JsonConvert.SerializeObject(newCinema);
            var postCinemaJSON = new StringContent(cinemaJSON, Encoding.UTF8, "application/json");

            var postRequest = client.PostAsync(EndPoints.PostCinema(), postCinemaJSON);
            var response = postRequest.Result;

            return response;
        }

        public static void DeleteCinemaById(HttpClient client, long Id)
        {
            var deleteRequest = client.DeleteAsync(EndPoints.DeleteCinema(Id));
        }
    }
}
