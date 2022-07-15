using Newtonsoft.Json;

namespace Session_2_1_HW
{
    public class BranchJSONModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

    }
}
