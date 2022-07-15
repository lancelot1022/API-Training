using Newtonsoft.Json;

namespace Session_3_HW.DataModels
{
    public class StateJSONModel
    {
        [JsonProperty("StateID")]
        public int StateID { get; set; }

        [JsonProperty("StateName")]
        public string StateName { get; set; }

        [JsonProperty("StateAbbreviation")]
        public string StateAbbreviation { get; set; }
    }
}
