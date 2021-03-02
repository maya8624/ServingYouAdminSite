using Newtonsoft.Json;

namespace ServingyouAdmin.Classes
{
    public class MenuApi
    {
        [JsonProperty("id")]
        public string MenuId { get; set; }

        [JsonProperty("available")]
        public bool Available { get; set; }

        [JsonProperty("menuName")]
        public string MenuName { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("special")]
        public bool Special { get; set; }


    }
}
