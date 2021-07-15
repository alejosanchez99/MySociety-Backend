

namespace MySociety.Bussines.Contribute.Interface
{
    using MySociety.Entities.Data.Contribute;
    using MySociety.Entities.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICommentBussines
    {
        Task<Comment> GetAsync(string id);
        Task<List<UserComment>> GetAsync(string societyId, string contributeId);
        Task<List<Comment>> GetAllAsync();
        Task<string> InsertAsync(Comment comment);
        Task<string> UpdateAsync(Comment comment);
        Task<string> DeleteAsync(string id);
    }
}
