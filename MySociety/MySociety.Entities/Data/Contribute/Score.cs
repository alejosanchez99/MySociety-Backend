namespace MySociety.Entities.Data.Contribute
{
    using Newtonsoft.Json;

    public class Score : BaseEntity
    {
        [JsonProperty("userID")]
        public string UserId { get; set; }

        [JsonProperty("societyId")]
        public string SocietyId { get; set; }

        [JsonProperty("contributeID")]
        public string ContributeId { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }
}
