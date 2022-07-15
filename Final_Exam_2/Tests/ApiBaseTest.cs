using Final_Exam_B.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace Final_Exam_B.Tests
{
    public class ApiBaseTest
    {
        public RestClient RestClient { get; set; }

        public CinemaJSON AddCinema { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            RestClient = new RestClient();
        }

        [TestCleanup]
        public void CleanUp()
        {

        }
    }
}
