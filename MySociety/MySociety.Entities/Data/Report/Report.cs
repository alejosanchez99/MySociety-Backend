namespace MySociety.Entities.Data.Report
{
    using Newtonsoft.Json;
    public class Report : BaseEntity
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("societyId")]
        public string SocietyId { get; set; }
        [JsonProperty("reasonId")]
        public string ReasonId { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}
