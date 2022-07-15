using Newtonsoft.Json;


namespace Final_Exam_B.DataModels
{
    public class CinemaJSON
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("branchId")]
        public long branchId { get; set; }

        [JsonProperty("id")]
        public long id { get; set; }

    }
}
