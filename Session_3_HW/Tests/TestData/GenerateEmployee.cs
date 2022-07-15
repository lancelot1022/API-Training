using Session_3_HW.DataModels;

namespace Session_3_HW.Tests.TestData
{
    public class GenerateEmployee
    {
        public static EmployeeJSONModel newEmployee1()
        {
            return new EmployeeJSONModel
            {
                EmpFirstName = "Alphinaud",
                EmpLastName = "Leveilleur",
                EmpAddress = "3780 Elliot Avenue",
                StateID = 31,
                CityID = 4322,
                DepartmentID = 7643,
                CityObj = new CityJSONModel
                {
                    CityID = 4322,
                    CityName = "Seattle"
                },
                StateObj = new StateJSONModel
                {
                    StateID = 31,
                    StateName = "New York",
                    StateAbbreviation = "NY"
                },
                DepartmentObj = new DepartmentJSONModel
                {
                    DepartmentID = 7643,
                    DepartmentName = "Chirurgeon"
                }
            };
        }
    }
}
