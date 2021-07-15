namespace MySociety.Bussines.Report
{
    using MySociety.Entities.Data.Report;
    using MySociety.Entities.Data.Reason;
    using MySociety.Entities.Data.Society;
    using MySociety.Entities.Data.User;
    using MySociety.Repository;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ReportBussines : BaseBussines, IReportBussines
    {
        public ReportBussines(IRepositoryService repositoryService) : base(repositoryService)
        {
        }

        public async Task<List<Report>> GetAllAsync()
        {
            return this.repositoryService.GetByFilterAsync<Report>(null).ToList();
        }

        public async Task<string> InsertAsync(Report report)
        {
            string userId = this.repositoryService.GetByFilterAsync<User>(user => user.Id == report.UserId).FirstOrDefault().ToString();

            string societyId = this.repositoryService.GetByFilterAsync<Society>(society => society.Id == report.SocietyId).FirstOrDefault().ToString();

            string reasonId = this.repositoryService.GetByFilterAsync<Reason>(reason => reason.Id == report.ReasonId).FirstOrDefault().ToString();

            return ValidateEmptyFields(userId, societyId, reasonId) ? string.Empty : await this.repositoryService.InsertAsync(report);
        }

        private static bool ValidateEmptyFields(string userId, string societyId, string reasonId)
        {
            return string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(societyId) || string.IsNullOrEmpty(reasonId);
        }
    }
}
