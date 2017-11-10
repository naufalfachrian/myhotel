using System;
using Newtonsoft.Json;

namespace MyHotel.Models
{
    public class RoomModel
    {
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }

        [JsonProperty("size")]
        public String Size { get; set; }

        [JsonProperty("bed_type")]
        public String BedType { get; set; }

        [JsonProperty("view")]
        public String View { get; set; }

        [JsonProperty("rate")]
        public Double Rate { get; set; }

        [JsonProperty("image_url")]
        public String ImageUrl { get; set; }
    }
}
