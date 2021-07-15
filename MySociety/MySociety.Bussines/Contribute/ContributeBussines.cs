namespace MySociety.Bussines.Contribute
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using MySociety.Bussines.Contribute.Interface;
    using MySociety.Entities.Data.Contribute;
    using MySociety.Repository;
    using MySociety.Utilities.Storage;

    public class ContributeBussines : BaseBussines, IContributeBussines
    {
        private IStorageUtilities _storageUtilities;

        public ContributeBussines(IRepositoryService repositoryService, IStorageUtilities storageUtilities) : base(repositoryService)
        {
            this._storageUtilities = storageUtilities;
        }

        public async Task<Contribute> GetAsync(string id)
        {
            return await this.repositoryService.GetAsync<Contribute>(id);
        }

        public async Task<List<Contribute>> GetAllAsync(string userId, string societyId)
        {
            List<Contribute> contributes = this.repositoryService.GetByFilterAsync<Contribute>(contribute => contribute.SocietyId == societyId).ToList();

            List<string> contributesId = contributes.Select(contribute => contribute.Id).ToList();
            List<Score> contributesScores = this.repositoryService.GetByFilterAsync<Score>(score => contributesId.Contains(score.ContributeId)).ToList();

            contributes.ForEach(contribute =>
            {
                Score scoreUser = contributesScores.Where(score => score.UserId == userId && score.ContributeId == contribute.Id).FirstOrDefault();

                contribute.UserScore = scoreUser != null ? scoreUser.Value : 0;
                contribute.TotalContributeScore = contributesScores.Where(score => score.ContributeId == contribute.Id).Count();
                contribute.TotalValueScore = contributesScores.Where(score => score.ContributeId == contribute.Id).Sum(score => score.Value);
            });

            return contributes.ToList();
        }

        public async Task<string> InsertAsync(Contribute contribute)
        {
            if (contribute.ImageArray != null || !string.IsNullOrEmpty(contribute.Image))
            {
                if (this._storageUtilities.ValidateFileExistStorage(contribute.Image))
                {
                    contribute.Image = this._storageUtilities.UploadStorageFile(contribute.Id, new MemoryStream(contribute.ImageArray));
                }
            }

            return await this.repositoryService.InsertAsync(contribute);
        }

        public async Task<string> UpdateAsync(Contribute contribute)
        {
            return await this.repositoryService.UpdateAsync(contribute);
        }

        public async Task<string> DeleteAsync(string id)
        {
            return await this.repositoryService.DeleteAsync<Contribute>(id);
        }
    }
}
