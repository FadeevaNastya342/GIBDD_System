using System;
using Newtonsoft.Json;

namespace GIBDD_System.Models
{
    public class FineDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("car_plate")]
        public string CarPlate { get; set; }

        [JsonProperty("license_number")]
        public string LicenseNumber { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("violation_date")]
        public DateTime ViolationDate { get; set; }

        [JsonProperty("violation_type")]
        public string ViolationType { get; set; }

        [JsonProperty("photo_url")]
        public string PhotoUrl { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}