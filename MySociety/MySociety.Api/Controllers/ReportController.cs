using Microsoft.AspNetCore.Mvc;
using MySociety.Bussines.Report;
using MySociety.Entities.Data.Report;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySociety.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IReportBussines _reportBussines;
        public ReportController(IReportBussines _reportBussines)
        {
            this._reportBussines = _reportBussines;
        }

        [HttpGet]
        public async Task<ActionResult<Report>> GetAllAsync()
        {
            List<Report> reports = await this._reportBussines.GetAllAsync();
            return reports != null ? this.Ok(reports) : (ActionResult<Report>)this.NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<string>> InsertAsync(Report report)
        {
            string reportId = await this._reportBussines.InsertAsync(report);

            return !string.IsNullOrEmpty(reportId) ? this.Ok(reportId) : (ActionResult<string>)this.BadRequest();
        }
    }
}