using Newtonsoft.Json;

namespace Session_3_HW.DataModels
{
    public class CityJSONModel
    {
        [JsonProperty("CityID")]
        public int CityID { get; set; }

        [JsonProperty("CityName")]
        public string CityName { get; set; }
    }
}
