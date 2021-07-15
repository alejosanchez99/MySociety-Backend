namespace MySociety.Bussines.Reason
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MySociety.Entities.Data.Reason;

    public interface IReasonBussines
    {
        List<Reason> GetAll();
    }
}