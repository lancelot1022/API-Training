using Newtonsoft.Json;

namespace Session_3_HW.DataModels
{
    public class EmployeeJSONModel
    {
        [JsonProperty("EmployeeID")]
        public int EmployeeID { get; set; }

        [JsonProperty("EmpFirstName")]
        public string EmpFirstName { get; set; }

        [JsonProperty("EmpLastName")]
        public string EmpLastName { get; set; }

        [JsonProperty("EmpAddress")]
        public string EmpAddress { get; set; }

        [JsonProperty("StateID")]
        public int StateID { get; set; }

        [JsonProperty("CityID")]
        public int CityID { get; set; }

        [JsonProperty("DepartmentID")]
        public int DepartmentID { get; set; }

        [JsonProperty("CityObj")]
        public CityJSONModel CityObj { get; set; }

        [JsonProperty("DepartmentObj")]
        public DepartmentJSONModel DepartmentObj { get; set; }

        [JsonProperty("StateObj")]
        public StateJSONModel StateObj { get; set; }
    }
}
