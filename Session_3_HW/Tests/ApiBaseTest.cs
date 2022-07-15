using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Session_3_HW.DataModels;


namespace Session_3_HW.Tests
{
    public class ApiBaseTest
    {
        public RestClient RestClient { get; set; }

        public EmployeeJSONModel EmployeeDetails { get; set; }

        [TestInitialize]
        public void Initilize()
        {
            RestClient = new RestClient();
        }

        [TestCleanup]
        public void CleanUp()
        {

        }
    }
}
