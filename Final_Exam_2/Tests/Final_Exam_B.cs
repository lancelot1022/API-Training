using Final_Exam_B.DataModels;
using Final_Exam_B.Helpers;
using Final_Exam_B.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace Final_Exam_B.Tests
{
    [TestClass]
    public class Final_Exam_B : ApiBaseTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            AddCinema = Cinema_Helper.AddNewCinema(RestClient);
        }

        [TestMethod]
        public void GetAllCinema()
        {
            var cinemaId = AddCinema.id;

            //Send GET request to retrieve cinema list
            var getRequest = new RestRequest(EndPoints.GetAllCinema());
            var response = RestClient.Get<List<CinemaJSON>>(getRequest);

            //Assertion to verify GET request
            Assert.AreEqual(HttpStatusCode.OK,response.StatusCode);

            //Assertion to verify total no. of cinemas
            var cinemaCount = response.Data.Count;
            Assert.IsTrue(cinemaCount >= 1);

            //Assert to verify added cinema
            var newCinemaIndex = response.Data.FindIndex(i => i.id == cinemaId);
            Assert.AreEqual(AddCinema.name, response.Data[newCinemaIndex].name);
        }

        [TestMethod]
        public void DeleteAddedCinema()
        {
            var cinemaId = AddCinema.id;

            //Send DELETE request
            var deleteRequest = new RestRequest(EndPoints.DeleteCinema(cinemaId));
            var deleteResponse = RestClient.Delete(deleteRequest);

            //Assertion to verify DELETE request
            Assert.AreEqual(HttpStatusCode.OK, deleteResponse.StatusCode);


            //Send GET request to verify deleted cinema
            var getRequest = new RestRequest(EndPoints.GetCinemaById(cinemaId));
            var getResponse = RestClient.Get<List<CinemaJSON>>(getRequest);

            //Assertion to verify GET request
            Assert.AreEqual(HttpStatusCode.NotFound, getResponse.StatusCode);
        }

        [TestMethod]
        public void VerifyInvalidCinemaId()
        {
            var cinemaId = AddCinema.id;
            var invalidCinemaId = cinemaId + 5;

            //Send GET Request
            var getRequest = new RestRequest(EndPoints.GetCinemaById(invalidCinemaId));
            var response = RestClient.Get<List<CinemaJSON>>(getRequest);

            //Assertion to verify GET request
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
        
        [TestCleanup]
        public void TestCleanUp()
        {
            var cinemaId = AddCinema.id;
            Cinema_Helper.DeleteCinema(RestClient, cinemaId);
        }
    }
}
