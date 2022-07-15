using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Session_2_1_HW;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Session_2_2_HW
{
    [TestClass]
    public class Homework_2_2
    {
        public HttpClient httpClient { get; set; }
        const string baseURL = "https://magenicmovies-api.azurewebsites.net/";
        const string branchEndPoint = "branches";

        [TestInitialize]
        public void TestInitialize()
        {
            httpClient = new HttpClient();
        }


        [TestMethod]
        public void CreateAndVerifyBranch()
        {
            //Request URL
            var httpURL = $"{baseURL}{branchEndPoint}";

            var newBranch1 = new BranchJSONModel()
            {
                Name = "Parramatta Branch 01", //Debug data: Test Branch 204
                Address = "23 Victoria Road, NSW 2150", //Debug data: 04 First Street, WA 2343
            };

            var branchJSON = JsonConvert.SerializeObject(newBranch1);
            var postBranchRequest = new StringContent(branchJSON, Encoding.UTF8, "application/json");

            //Send POST request to add new branch
            var httpPostResponse = httpClient.PostAsync(httpURL, postBranchRequest);
            var httpPostResponseResult = httpPostResponse.Result;

            //POST request status code and Data
            var postResponseStatusCode = httpPostResponseResult.StatusCode;
            var postResponseData = httpPostResponseResult.Content.ReadAsStringAsync().Result;
            var branchData = JsonConvert.DeserializeObject<BranchJSONModel>(postResponseData);

            //Assertion to verify POST request is successful
            Assert.AreEqual(HttpStatusCode.Created, postResponseStatusCode);

            //Assertion to verify added branch data
            Assert.AreEqual(newBranch1.Name, branchData.Name);
            Assert.AreEqual(newBranch1.Address, branchData.Address);

        }
    }
}
