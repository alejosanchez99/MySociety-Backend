namespace MySociety.Bussines.Reason
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MySociety.Entities.Data.Reason;
    using MySociety.Repository;

    public class ReasonBussines : BaseBussines, IReasonBussines
    {
        public ReasonBussines(IRepositoryService repositoryService) : base(repositoryService)
        {
        }

        public List<Reason> GetAll()
        {
            return this.repositoryService.GetByFilterAsync<Reason>(null).ToList();
        }
    }
}
