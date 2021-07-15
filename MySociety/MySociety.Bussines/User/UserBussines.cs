namespace MySociety.Bussines.User
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using MySociety.Bussines.User.Interface;
    using MySociety.Entities.Data.Society;
    using MySociety.Entities.Data.User;
    using MySociety.Entities.Model;
    using MySociety.Repository;
    using MySociety.Utilities.Storage;

    public class UserBussines : BaseBussines, IUserBussines
    {
        private IStorageUtilities _storageUtilities;

        public UserBussines(IRepositoryService repositoryService, IStorageUtilities storageUtilities) : base(repositoryService)
        {
            this._storageUtilities = storageUtilities;
        }

        public async Task<string> InsertAsync(User user)
        {
            if (user.ImageArray != null || !string.IsNullOrEmpty(user.Image))
            {
                if (this._storageUtilities.ValidateFileExistStorage(user.Image))
                {
                    user.Image = this._storageUtilities.UploadStorageFile(user.Id, new MemoryStream(user.ImageArray));
                }
            }

            return await this.repositoryService.InsertAsync(user);
        }

        public async Task<UserSociety> GetUserSocietyAsync(string userId, string societyId)
        {
            User user = await this.repositoryService.GetAsync<User>(userId);
            Society society = await this.repositoryService.GetAsync<Society>(societyId);

            return new UserSociety
            {
                Society = society,
                UserId = user.Id,
                BelongsSociety = society != null && user != null ? user.UserBelongToSociety(society.Id) : false
            };
        }

        public async Task<User> GetAsync(string id)
        {
            return await this.repositoryService.GetAsync<User>(id);
        }

        public List<User> GetAll()
        {
            return this.repositoryService.GetByFilterAsync<User>(null).ToList();
        }
    }
}
