namespace MySociety.Entities.Data.Society
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using User;

    public class Society : BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonIgnore]
        public byte[] ImageArray { get; set; }

        [JsonProperty("users")]
        public List<User> Users { get; set; }

        [JsonProperty("presidentUserId")]
        public string PresidentUserId { get; set; }

        [JsonProperty("presidentUserName")]
        public string PresidentUserName { get; set; }
    }
}
