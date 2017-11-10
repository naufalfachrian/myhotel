using System;
using Newtonsoft.Json;

namespace MyHotel.Models
{
    public class FacilityModel
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }

        [JsonProperty("image_url")]
        public String ImageUrl { get; set; }
    }
}
