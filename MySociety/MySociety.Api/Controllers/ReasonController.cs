using Microsoft.AspNetCore.Mvc;
using MySociety.Bussines.Reason;
using MySociety.Entities.Data.Reason;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySociety.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReasonController : ControllerBase
    {
        private IReasonBussines _reasonBussines;
        public ReasonController(IReasonBussines _reasonBussines)
        {
            this._reasonBussines = _reasonBussines;
        }

        [HttpGet]
        public  ActionResult<Reason> GetAllAsync()
        {
            List<Reason> reasons = this._reasonBussines.GetAll();
            return reasons != null ? this.Ok(reasons) : (ActionResult<Reason>)this.NoContent();
        }
    }
}