namespace MySociety.Bussines.Society.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MySociety.Entities.Data.Society;

    public interface ISocietyBussines
    {
        Task<Society> GetAsync(string id);

        List<Society> GetAll();

        Task<string> InsertAsync(Society contribute);

        Task<string> UpdateAsync(Society contribute);

        Task<string> DeleteAsync(string id);

        Task<List<Society>> GetSocietiesNotAsociatedUserAsync(string userId);

        Task<bool> InsertUserToSociety(string userId, string societyId);
    }
}
