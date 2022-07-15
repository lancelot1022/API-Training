using Final_Exam_B.DataModels;
using Final_Exam_B.Resources;
using Final_Exam_B.Tests.TestData;
using RestSharp;

namespace Final_Exam_B.Helpers
{
    public class Cinema_Helper
    {
        public static CinemaJSON AddNewCinema(RestClient client)
        {
            var newCinema = GenerateCinema.newCinema_1();
            var postRequest = new RestRequest(EndPoints.PostCinema());

            postRequest.AddJsonBody(newCinema);
            var response = client.Post<CinemaJSON>(postRequest);
            return response.Data;
        }

        public static void DeleteCinema(RestClient client, long Id)
        {
            var deleteRequest = new RestRequest(EndPoints.DeleteCinema(Id));
            var response = client.Delete(deleteRequest);
        }
    }
}
