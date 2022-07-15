using System;
using System.Collections.Generic;
using System.Text;

namespace Session_3_HW.Resources
{
    public class EndPoints
    {
        public const string baseURL = "http://magenicautomation.azurewebsites.net:80";

        public static string GetEmployeeWithIdEndPoint(int Id) => $"{baseURL}/api/EmployeesAPI/GetEmployee/{Id}";

        public static string PostEmployee() => $"{baseURL}/api/EmployeesAPI/PostEmployee";

        public static string DeleteEmployeeWithId(int Id) => $"{baseURL}/api/EmployeesAPI/DeleteEmployee/{Id}";

    }
}
