namespace MySociety.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MySociety.Bussines.Contribute.Interface;
    using MySociety.Entities.Data.Contribute;
    using MySociety.Entities.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private ICommentBussines _commentBussines;

        public CommentController(ICommentBussines commentBussines)
        {
            this._commentBussines = commentBussines;
        }

        [HttpPost]
        public async Task<ActionResult<string>> InsertAsync(Comment comment)
        {
            string commentId = await this._commentBussines.InsertAsync(comment);
            return this.Ok(commentId);
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateAsync(Comment comment)
        {
            string commentId = await this._commentBussines.UpdateAsync(comment);
            return this.Ok(commentId);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Comment>> GetAsync(string id)
        {
            Comment comment = await this._commentBussines.GetAsync(id);
            return comment != null ? this.Ok(comment) : (ActionResult<Comment>)this.NoContent();
        }

        [HttpGet("{societyId}/{contributeId}")]

        public async Task<ActionResult<List<UserComment>>> GetAsync(string societyId, string contributeId)
        {
            List<UserComment> comment = await this._commentBussines.GetAsync(societyId, contributeId);
            return comment != null ? this.Ok(comment) : (ActionResult<List<UserComment>>)this.NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetAllAsync()
        {
            List<Comment> comment = await this._commentBussines.GetAllAsync();
            return comment != null ? this.Ok(comment) : (ActionResult<List<Comment>>)this.NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<string>> DeleteAsync(string id)
        {
            string commentId = await this._commentBussines.DeleteAsync(id);
            return commentId != null ? this.Ok(commentId) : (ActionResult<string>)this.NoContent();
        }
    }
}
