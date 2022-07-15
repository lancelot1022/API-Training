using RestSharp;
using Session_3_HW.DataModels;
using Session_3_HW.Resources;
using Session_3_HW.Tests.TestData;

namespace Session_3_HW.Helpers
{
    public class EmployeeHelper
    {
        public static EmployeeJSONModel AddNewEmployee(RestClient client)
        {
            var newEmp = GenerateEmployee.newEmployee1();
            var postRequest = new RestRequest(EndPoints.PostEmployee());

            postRequest.AddJsonBody(newEmp);
            var response = client.Post<EmployeeJSONModel>(postRequest);
            return response.Data;
        }

        public static void DeleteEmployee(RestClient client, int Id)
        {
            var deleteRequest = new RestRequest(EndPoints.DeleteEmployeeWithId(Id));
            var response = client.Delete(deleteRequest);
        }
    }
}
