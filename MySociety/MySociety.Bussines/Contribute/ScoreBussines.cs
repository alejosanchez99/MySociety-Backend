namespace MySociety.Bussines.Contribute
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MySociety.Entities.Data.Contribute;
    using MySociety.Entities.Data.User;
    using MySociety.Repository;

    public class ScoreBussines : BaseBussines, IScoreBussines
    {
        public ScoreBussines(IRepositoryService repositoryService) : base(repositoryService)
        {
        }

        public async Task<string> InsertAsync(Score score)
        {
            await this.UpdateUserRatingAsync(score);

            return await this.repositoryService.InsertAsync(score);
        }

        public async Task<string> UpdateAsync(Score score)
        {
            await this.UpdateUserRatingAsync(score);

            return await this.repositoryService.UpdateAsync(score);
        }

        private async Task UpdateUserRatingAsync(Score score)
        {
            List<Score> societyScoresByUser = this.repositoryService.GetByFilterAsync<Score>(rating => rating.UserId == score.UserId && rating.SocietyId == score.SocietyId).ToList();

            decimal totalScore = 1;
            decimal scoreValue = score.Value;

            if (societyScoresByUser.Any())
            {
                totalScore += societyScoresByUser.Count();
                scoreValue += societyScoresByUser.Sum(x => x.Value);
            }

            Rating rating = new Rating()
            {
                UserId = score.UserId,
                SocietyId = score.SocietyId,
                Value = (scoreValue * totalScore) / 100
            };

            Rating actualRating = this.repositoryService.GetByFilterAsync<Rating>(rating => rating.UserId == score.UserId && rating.SocietyId == score.SocietyId).FirstOrDefault();

            if (actualRating != null)
            {
                actualRating.Value = rating.Value;
                await this.repositoryService.UpdateAsync(actualRating);
            }
            else
            {
                await this.repositoryService.InsertAsync(rating);
            }
        }
    }
}
