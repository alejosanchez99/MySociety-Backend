namespace MySociety.Entities.Data.User
{
    using System.Collections.Generic;
    using System.Linq;
    using MySociety.Entities.Data.Society;
    using Newtonsoft.Json;

    public class User : BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonIgnore]
        public byte[] ImageArray { get; set; }

        [JsonProperty("societies")]
        public List<Society> Societies { get; set; }

        public bool UserBelongToSociety(string societyId)
        {
            return (this.Societies != null) ? this.Societies.Any(x => x.Id == societyId) : false;
        }
    }
}
