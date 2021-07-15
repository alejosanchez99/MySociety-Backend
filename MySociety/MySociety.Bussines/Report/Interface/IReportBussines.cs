namespace MySociety.Bussines.Report
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MySociety.Entities.Data.Report;

    public interface IReportBussines
    {
        Task<List<Report>> GetAllAsync();
        Task<string> InsertAsync(Report report);
    }
}