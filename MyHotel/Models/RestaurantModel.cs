using System;
using Newtonsoft.Json;

namespace MyHotel.Models
{
    public class RestaurantModel
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }

        [JsonProperty("house_of_operation")]
        public String HouseOfOperation { get; set; }

        [JsonProperty("dress_code")]
        public String DressCode { get; set; }

        [JsonProperty("how_to_reserve")]
        public String ReservationProcedure { get; set; }

        [JsonProperty("menu_list_url")]
        public String MenuListUrl { get; set; }

        [JsonProperty("image_url")]
        public String ImageUrl { get; set; }
    }
}
