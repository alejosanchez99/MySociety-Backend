namespace MySociety.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MySociety.Bussines.Contribute;
    using MySociety.Entities.Data.Contribute;

    [ApiController]
    [Route("api/[controller]")]
    public class ScoreController : ControllerBase
    {
        private IScoreBussines _scoreBussines;

        public ScoreController(IScoreBussines scoreBussines)
        {
            this._scoreBussines = scoreBussines;
        }

        [HttpPost]
        public async Task<ActionResult<string>> InsertAsync(Score score)
        {
            string scoreId = await this._scoreBussines.InsertAsync(score);
            return this.Ok(scoreId);
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateAsync(Score score)
        {
            string contributeId = await this._scoreBussines.UpdateAsync(score);
            return this.Ok(contributeId);
        }
    }
}
