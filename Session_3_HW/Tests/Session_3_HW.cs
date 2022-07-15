using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Session_3_HW.DataModels;
using Session_3_HW.Helpers;
using Session_3_HW.Resources;
using System.Net;

namespace Session_3_HW.Tests
{
    [TestClass]
    public class Session_3_HW : ApiBaseTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            EmployeeDetails = EmployeeHelper.AddNewEmployee(RestClient);
        }

        [TestMethod]
        public void GetEmployee()
        {
            var getRequest = new RestRequest(EndPoints.GetEmployeeWithIdEndPoint(EmployeeDetails.EmployeeID));

            var response = RestClient.Get<EmployeeJSONModel>(getRequest);

            Assert.AreEqual(HttpStatusCode.OK,response.StatusCode);
            Assert.AreEqual(EmployeeDetails.EmpFirstName, response.Data.EmpFirstName);
            Assert.AreEqual(EmployeeDetails.EmpLastName, response.Data.EmpLastName);
            Assert.AreEqual(EmployeeDetails.EmpAddress, response.Data.EmpAddress);
            Assert.AreEqual(EmployeeDetails.StateObj.StateName, response.Data.StateObj.StateName);
            Assert.AreEqual(EmployeeDetails.CityObj.CityName, response.Data.CityObj.CityName);
            Assert.AreEqual(EmployeeDetails.DepartmentObj.DepartmentName, response.Data.DepartmentObj.DepartmentName);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            EmployeeHelper.DeleteEmployee(RestClient, EmployeeDetails.EmployeeID);
        }
    }
}
