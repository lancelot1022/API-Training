using Final_Exam_A.DataModels;
using Final_Exam_A.Helpers;
using Final_Exam_A.Resources;
using Final_Exam_A.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Final_Exam_A.Tests
{
    [TestClass]
    public class Final_Exam_A : ApiBaseTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            AddCinemaResponse = Cinema_Helper.AddNewCinema(HttpClient);
        }

        [TestMethod]
        public void VerifyNewCinema()
        {
            //Assertion to verify POST request
            Assert.AreEqual(HttpStatusCode.Created, AddCinemaResponse.StatusCode);
        }

        [TestMethod]
        public void UpdateCinema()
        {
            var newCinema = AddCinemaResponse.Content.ReadAsStringAsync().Result;
            var newCinemaJSON = JsonConvert.DeserializeObject<CinemaJSON>(newCinema);
            var cinemaId = newCinemaJSON.id;

            //Create and serialize update object
            var updateCinemaData = GenerateCinema.updateCinema_1();
            var cinemaJSON = JsonConvert.SerializeObject(updateCinemaData);
            var putCinemaJSON = new StringContent(cinemaJSON, Encoding.UTF8, "application/json");

            //Send PUT request
            var putRequest = HttpClient.PutAsync(EndPoints.PutCinema(cinemaId), putCinemaJSON);
            var putResponse = putRequest.Result;

            //Assertion to verify PUT request
            Assert.AreEqual(HttpStatusCode.OK, putResponse.StatusCode);

            //Send GET request
            var getRequest = HttpClient.GetAsync(EndPoints.GetAllCinema());
            var getResponse = getRequest.Result;
            var getResponseContent = getResponse.Content;

            //Assertion to verify GET request
            Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);

            //Deserialize Response and verify updated Cinema
            var getResponseData = getResponseContent.ReadAsStringAsync();
            var listCinema = JsonConvert.DeserializeObject<List<CinemaJSON>>(getResponseData.Result);
            var newCinemaIndex = listCinema.FindIndex(i => i.id == cinemaId);
            Assert.AreEqual(updateCinemaData.name, listCinema[newCinemaIndex].name);
        }

        [TestMethod]
        public void VerifyInvalidCinemaId()
        {
            var newCinema = AddCinemaResponse.Content.ReadAsStringAsync().Result;
            var newCinemaJSON = JsonConvert.DeserializeObject<CinemaJSON>(newCinema);
            var invalidCinemaId = newCinemaJSON.id + 5;

            //Send Get request
            var getRequest = HttpClient.GetAsync(EndPoints.GetCinemaById(invalidCinemaId));
            var getResponse = getRequest.Result;

            //Assertion to verify GET request
            Assert.AreEqual(HttpStatusCode.NotFound, getResponse.StatusCode);

        }

        [TestCleanup]
        public void TestCleanUp()
        {
            var newCinema = AddCinemaResponse.Content.ReadAsStringAsync().Result;
            var newCinemaJSON = JsonConvert.DeserializeObject<CinemaJSON>(newCinema);
            var cinemaId = newCinemaJSON.id;
            Cinema_Helper.DeleteCinemaById(HttpClient, cinemaId);
        }
    }
}
