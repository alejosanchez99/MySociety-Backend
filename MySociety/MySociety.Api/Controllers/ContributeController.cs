namespace MySociety.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MySociety.Bussines.Contribute.Interface;
    using MySociety.Entities.Data.Contribute;

    [ApiController]
    [Route("api/[controller]")]
    public class ContributeController : ControllerBase
    {
        private IContributeBussines _contributeBussines;

        public ContributeController(IContributeBussines contributeBussines)
        {
            this._contributeBussines = contributeBussines;
        }

        [HttpPost]
        public async Task<ActionResult<string>> InsertAsync(Contribute contribute)
        {
            string contributeId = await this._contributeBussines.InsertAsync(contribute);
            return this.Ok(contributeId);
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateAsync(Contribute contribute)
        {
            string contributeId = await this._contributeBussines.UpdateAsync(contribute);
            return this.Ok(contributeId);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Contribute>> GetAsync(string id)
        {
            Contribute contribute = await this._contributeBussines.GetAsync(id);
            return contribute != null ? this.Ok(contribute) : (ActionResult<Contribute>)this.NoContent();
        }

        [HttpGet("{userId}/{societyId}")]
        public async Task<ActionResult<List<Contribute>>> GetAllAsync(string userId, string societyId)
        {
            List<Contribute> contributes = await this._contributeBussines.GetAllAsync(userId, societyId);
            return contributes != null ? this.Ok(contributes) : (ActionResult<List<Contribute>>)this.NoContent();
        }

        [HttpDelete]

        public async Task<ActionResult<string>> DeleteAsync(string id)
        {
            string contributeId = await this._contributeBussines.DeleteAsync(id);
            return contributeId != null ? this.Ok(contributeId) : (ActionResult<string>)this.NoContent();
        }
    }
}