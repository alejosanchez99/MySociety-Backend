namespace MySociety.Bussines.User.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MySociety.Entities.Data.User;
    using MySociety.Entities.Model;

    public interface IUserBussines
    {
        Task<User> GetAsync(string id);

        List<User> GetAll();

        Task<UserSociety> GetUserSocietyAsync(string userId, string societyId);

        Task<string> InsertAsync(User user);
    }
}
