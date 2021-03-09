using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace JwelleryStore.Common.DTO
{
    public class UserDetailDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("userName")]
        public string UserName { get; set; }
        [JsonPropertyName("roleName")]
        public string RoleName { get; set; }
        [JsonPropertyName("discountPrice")]
        public double? DiscountPrice { get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; }

    }
}
