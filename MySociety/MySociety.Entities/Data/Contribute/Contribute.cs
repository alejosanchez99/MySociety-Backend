namespace MySociety.Entities.Data.Contribute
{
    using Newtonsoft.Json;
    using System;

    public class Contribute : BaseEntity
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("societyId")]
        public string SocietyId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonIgnore]
        public byte[] ImageArray { get; set; }

        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("userScore")]
        public int UserScore { get; set; }

        [JsonProperty("totalValueScore")]
        public decimal TotalValueScore { get; set; }

        [JsonProperty("totalContributeScore")]
        public decimal TotalContributeScore { get; set; }
    }
}
