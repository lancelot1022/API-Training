using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Net;


namespace Session_2_1_HW
{
    [TestClass]
    public class Homework
    {
        const string baseURL = "https://magenicmovies-api.azurewebsites.net/";
        const string branchEndPoint = "branches";

        [TestMethod]
        public void CreateBranch()
        {
            var restClient = new RestClient();
            var restRequest = new RestRequest($"{baseURL}{branchEndPoint}");
            

            var newBranch1 = new BranchJSONModel()
            {
                Name = "Test Branch 102",
                Address = "56 North South St., VIC 3392",
            };

            //Send POST request to add new branch
            restRequest.AddJsonBody(newBranch1);
            var response = restClient.Post(restRequest);

            //Verify Response Code
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            //Send GET request to retrieve added branch name and address.
            Methods m = new Methods();
            var newBranchID = m.BranchRecordCount();
            var restRequestGet = new RestRequest($"{baseURL}{branchEndPoint}/{newBranchID}");
            var responseGet = restClient.Get<BranchJSONModel>(restRequestGet);

            //Verify Branch Name and Address
            Assert.AreEqual(newBranch1.Name, responseGet.Data.Name);
            Assert.AreEqual(newBranch1.Address, responseGet.Data.Address);

        }
    }
}
