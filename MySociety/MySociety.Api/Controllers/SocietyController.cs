namespace MySociety.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MySociety.Bussines.Society.Interface;
    using MySociety.Entities.Data.Society;

    [ApiController]
    [Route("api/[controller]")]
    public class SocietyController : ControllerBase
    {
        private ISocietyBussines _societyBussines;

        public SocietyController(ISocietyBussines societyBussines)
        {
            this._societyBussines = societyBussines;
        }

        [HttpPost]
        public async Task<ActionResult<string>> InsertAsync(Society society)
        {
            string societyId = await this._societyBussines.InsertAsync(society);
            return this.Ok(societyId);
        }

        [HttpPut("{userId}/{societyId}")]
        public async Task<ActionResult<string>> InsertUserToSociety(string userId, string societyId)
        {
            bool userAddedToSociety = await this._societyBussines.InsertUserToSociety(userId, societyId);
            return this.Ok(userAddedToSociety);
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateAsync(Society society)
        {
            string societyId = await this._societyBussines.UpdateAsync(society);
            return this.Ok(societyId);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<Society>>> GetSocietiesNotAsociatedUserAsync(string userId)
        {
            List<Society> societies = await this._societyBussines.GetSocietiesNotAsociatedUserAsync(userId);
            return societies != null ? this.Ok(societies) : (ActionResult<List<Society>>)this.NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<Society>>> GetAllAsync()
        {
            List<Society> societies = this._societyBussines.GetAll();
            return societies != null ? this.Ok(societies) : (ActionResult<List<Society>>)this.NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<string>> DeleteAsync(string id)
        {
            string societyId = await this._societyBussines.DeleteAsync(id);
            return societyId != null ? this.Ok(societyId) : (ActionResult<string>)this.NoContent();
        }
    }
}
