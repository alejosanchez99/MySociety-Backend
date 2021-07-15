namespace MySociety.Entities
{
    using System;
    using System.Text.Json;
    using Newtonsoft.Json;

    public class BaseEntity
    {
        [JsonProperty("id")]
        public string Id
        {
            get
            {
                if (string.IsNullOrEmpty(this.id))
                {
                    this.id = Guid.NewGuid().ToString();
                }

                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        private string id;
    }
}