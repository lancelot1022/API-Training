using Final_Exam_A.DataModels;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Final_Exam_A.Tests
{
    public class ApiBaseTest
    {
        public HttpClient HttpClient { get; set; }

        public HttpResponseMessage AddCinemaResponse { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            HttpClient = new HttpClient();
        }

        [TestCleanup]
        public void CleanUp()
        {

        }
    }
}
