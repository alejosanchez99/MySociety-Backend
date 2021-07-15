namespace MySociety.Bussines.User.Interface
{
    using System.Threading.Tasks;
    using MySociety.Entities.Data.User;

    interface IRatingBussines
    {
        Task<string> InsertAsync(Rating user);

        Task<string> UpdateAsync(Rating user);
    }
}
