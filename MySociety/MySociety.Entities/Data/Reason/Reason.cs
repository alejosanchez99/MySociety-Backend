namespace MySociety.Entities.Data.Reason
{
    using Newtonsoft.Json;

    public class Reason : BaseEntity
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
