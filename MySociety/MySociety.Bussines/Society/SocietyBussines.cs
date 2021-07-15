namespace MySociety.Bussines.Society
{
    using Interface;
    using MySociety.Entities.Data.Society;
    using MySociety.Entities.Data.User;
    using MySociety.Repository;
    using MySociety.Utilities.Storage;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class SocietyBussines : BaseBussines, ISocietyBussines
    {
        private IStorageUtilities _storageUtilities;

        public SocietyBussines(IRepositoryService repositoryService, IStorageUtilities storageUtilities) : base(repositoryService)
        {
            this._storageUtilities = storageUtilities;
        }

        public async Task<Society> GetAsync(string id)
        {
            Society contribute = await this.repositoryService.GetAsync<Society>(id);

            return contribute;
        }

        public async Task<List<Society>> GetSocietiesNotAsociatedUserAsync(string userId)
        {
            User user = await this.repositoryService.GetAsync<User>(userId);

            List<string> userSocietiesIds = user != null ? user.Societies.Select(x => x.Id).ToList() : new List<string>();

            return this.repositoryService.GetByFilterAsync<Society>(x => !userSocietiesIds.Contains(x.Id)).ToList();
        }

        public List<Society> GetAll()
        {
            return this.repositoryService.GetByFilterAsync<Society>(null).ToList();
        }

        public async Task<string> InsertAsync(Society society)
        {
            if (society.ImageArray != null || !string.IsNullOrEmpty(society.Image))
            {
                if (this._storageUtilities.ValidateFileExistStorage(society.Image))
                {
                    society.Image = this._storageUtilities.UploadStorageFile(society.Id, new MemoryStream(society.ImageArray));
                }
            }

            return await this.repositoryService.InsertAsync(society);
        }

        public async Task<bool> InsertUserToSociety(string userId, string societyId)
        {
            bool userAddedToSociety = false;

            Society society = await this.repositoryService.GetAsync<Society>(societyId);
            User user = await this.repositoryService.GetAsync<Entities.Data.User.User>(userId);

            if (user != null && society != null)
            {
                await this.AddSocietyToUser(society, user);
                await this.AddUserTosociety(society, user);

                userAddedToSociety = true;
            }

            return userAddedToSociety;
        }

        private async Task AddUserTosociety(Society society, User user)
        {
            if (society.Users == null)
            {
                society.Users = new List<User>();
            }

            if (!society.Users.Any(societyUser => societyUser.Id == user.Id))
            {
                society.Users.Add(user);
                await this.repositoryService.UpdateAsync(society);
            }
        }

        private async Task AddSocietyToUser(Society society, User user)
        {
            if (user.Societies == null)
            {
                user.Societies = new List<Society>();
            }

            if (!user.Societies.Any(societyUser => societyUser.Id == society.Id))
            {
                user.Societies.Add(society);
                await this.repositoryService.UpdateAsync(user);
            }
        }

        public async Task<string> UpdateAsync(Society society)
        {
            return await this.repositoryService.UpdateAsync(society);
        }

        public async Task<string> DeleteAsync(string id)
        {
            return await this.repositoryService.DeleteAsync<Society>(id);
        }
    }
}
