using System;
using Newtonsoft.Json;

namespace MyHotel.Models
{
    public class ResponseModel<T>
    {
        [JsonProperty("status")]
        public Int32 Status { get; set; }

        [JsonProperty("message")]
        public String Message { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
