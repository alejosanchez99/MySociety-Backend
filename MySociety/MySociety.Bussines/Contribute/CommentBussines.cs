

namespace MySociety.Bussines.Contribute
{
    using MySociety.Bussines.Contribute.Interface;
    using MySociety.Entities.Data.Contribute;
    using MySociety.Entities.Data.User;
    using MySociety.Entities.Model;
    using MySociety.Repository;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class CommentBussines : BaseBussines, ICommentBussines
    {
        public CommentBussines(IRepositoryService repositoryService) : base(repositoryService)
        {

        }

        public async Task<Comment> GetAsync(string id)
        {
            return await this.repositoryService.GetAsync<Comment>(id);
        }

        public async Task<List<UserComment>> GetAsync(string societyId, string contributeId)
        
        {
            List<Comment> comments = this.repositoryService.GetByFilterAsync<Comment>(comment => comment.SocietyId == societyId && comment.ContributeId == contributeId).ToList();
            List<User> users = this.repositoryService.GetByFilterAsync<User>(null).ToList().Where(user => comments.Any(comment => user.Id == comment.UserId)).ToList();

            List<UserComment> userComents = new List<UserComment>();

            comments.ForEach(comment =>
            {
                string completeName = users.Where(user => user.Id == comment.UserId).Select(user => string.Concat(user.Name, " ", user.LastName)).First();
                UserComment userComment = new UserComment()
                {
                    CommentId = comment.Id,
                    CreationDate = comment.CreationDate,
                    UserName = completeName,
                    UserImage = users.Find(user => user.Id == comment.UserId).Image,
                    CommentText = comment.Text
                };

                userComents.Add(userComment);
            });
            
            return userComents;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return this.repositoryService.GetByFilterAsync<Comment>(null).ToList();
        }

        public async Task<string> InsertAsync(Comment comment)
        {
            return await this.repositoryService.InsertAsync(comment);
        }

        public async Task<string> UpdateAsync(Comment comment)
        {
            return await this.repositoryService.UpdateAsync(comment);
        }

        public Task<string> DeleteAsync(string id)
        {
            return this.repositoryService.DeleteAsync<Comment>(id);
        }
    }
}
