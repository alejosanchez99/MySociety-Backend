namespace MySociety.Bussines
{
    using Repository;

    public class BaseBussines
    {
        protected IRepositoryService repositoryService;

        public BaseBussines(IRepositoryService repositoryService)
        {
            this.repositoryService = repositoryService;
        }
    }
}
