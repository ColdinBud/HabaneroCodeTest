using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HabaneroCodeTest.Models
{
    public class BaseApiData
    {
        [JsonProperty("BrandId")]
        public string brandID { get; set; }
        [JsonProperty("ApiKey")]
        public string apiKey { get; set; }

        public BaseApiData()
        {
            brandID = "0d51cf4c-1d02-e711-80d9-000d3a802d1d";
            apiKey = "A50C2BDA-4ACF-42E8-AE22-971A9A9F47C7";
        }

        public BaseApiData(string _brandID, string _apiKey)
        {
            brandID = _brandID;
            apiKey = _apiKey;
        }
    }
}