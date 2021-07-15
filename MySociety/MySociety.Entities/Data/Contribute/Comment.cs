using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySociety.Entities.Data.Contribute
{
    public class Comment : BaseEntity
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("societyId")]
        public string SocietyId { get; set; }

        [JsonProperty("contributeId")]
        public string ContributeId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }
    }
}
