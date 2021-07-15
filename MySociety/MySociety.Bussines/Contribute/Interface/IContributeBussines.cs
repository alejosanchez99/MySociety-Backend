namespace MySociety.Bussines.Contribute.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MySociety.Entities.Data.Contribute;

    public interface IContributeBussines
    {
        Task<Contribute> GetAsync(string id);
        Task<List<Contribute>> GetAllAsync(string userId, string socityId);
        Task<string> InsertAsync(Contribute contribute);

        Task<string> UpdateAsync(Contribute contribute);

        Task<string> DeleteAsync(string id);
    }
}
