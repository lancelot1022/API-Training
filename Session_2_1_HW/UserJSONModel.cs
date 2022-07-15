using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session_2_1_HW
{
    class UserJSONModel
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("FirstName", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [JsonProperty("MiddleName", NullValueHandling = NullValueHandling.Ignore)]
        public string MiddleName { get; set; }

        [JsonProperty("LastName", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        [JsonProperty("BirthDay", NullValueHandling = NullValueHandling.Ignore)]
        public BirthDay BirthDay { get; set; }

        [JsonProperty("AccessType", NullValueHandling = NullValueHandling.Ignore)]
        public long? AccessType { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }
    public partial class BirthDay
    {
        [JsonProperty("Year")]
        public long Year { get; set; }

        [JsonProperty("Month")]
        public long Month { get; set; }

        [JsonProperty("Day")]
        public long Day { get; set; }
    }

    public partial class BirthDayClass
    {
        [JsonProperty("year")]
        public long Year { get; set; }

        [JsonProperty("month")]
        public long Month { get; set; }

        [JsonProperty("day")]
        public long Day { get; set; }
    }
}
