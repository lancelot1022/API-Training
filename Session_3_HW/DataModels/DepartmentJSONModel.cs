using Newtonsoft.Json;

namespace Session_3_HW.DataModels
{
    public class DepartmentJSONModel
    {
        [JsonProperty("DepartmentID")]
        public int DepartmentID { get; set; }

        [JsonProperty("DepartmentName")]
        public string DepartmentName { get; set; }
    }
}
