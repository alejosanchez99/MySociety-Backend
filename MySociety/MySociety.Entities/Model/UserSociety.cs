namespace MySociety.Entities.Model
{
    using System.Collections.Generic;
    using MySociety.Entities.Data.Society;
    using MySociety.Entities.Data.User;

    public class UserSociety
    {
        public string UserId { get; set; }

        public Society Society { get; set; }

        public bool BelongsSociety { get; set; }

        public List<User> FeaturesUsers { get; set; }
    }
}
