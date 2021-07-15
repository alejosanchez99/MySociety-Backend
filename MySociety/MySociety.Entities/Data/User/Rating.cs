namespace MySociety.Entities.Data.User
{
    using Newtonsoft.Json;

    public class Rating : BaseEntity
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("societyId")]
        public string SocietyId { get; set; }
        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
}
