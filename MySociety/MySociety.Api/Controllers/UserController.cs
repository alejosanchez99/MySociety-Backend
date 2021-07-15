namespace MySociety.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MySociety.Bussines.User.Interface;
    using MySociety.Entities.Data.User;
    using MySociety.Entities.Model;

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserBussines _userBussines;

        public UserController(IUserBussines userBussines)
        {
            this._userBussines = userBussines;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetAsync(string id)
        {
            User user = await this._userBussines.GetAsync(id);
            return user != null ? this.Ok(user) : (ActionResult<User>)this.NoContent();
        }

        [HttpGet("{userId}/{societyId}")]
        public async Task<ActionResult<UserSociety>> GetAsync(string userId, string societyId)
        {
            UserSociety userSociety = await this._userBussines.GetUserSocietyAsync(userId, societyId);
            return userSociety != null ? this.Ok(userSociety) : (ActionResult<UserSociety>)this.NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllAsync()
        {
            List<User> users = this._userBussines.GetAll();
            return users != null ? this.Ok(users) : (ActionResult<List<User>>)this.NoContent();
        }
    }
}
