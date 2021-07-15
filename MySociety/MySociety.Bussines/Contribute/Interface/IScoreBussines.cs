namespace MySociety.Bussines.Contribute
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MySociety.Entities.Data.Contribute;

    public interface IScoreBussines
    {
        Task<string> InsertAsync(Score score);

        Task<string> UpdateAsync(Score score);
    }
}
