using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/careercloud/applicant/v1")]
    public class ApplicantWorkHistoryController : ApiController
    {
        private ApplicantWorkHistoryLogic _logic;

        public ApplicantWorkHistoryController()
        {
            _logic = new ApplicantWorkHistoryLogic(new EFGenericRepository<ApplicantWorkHistoryPoco>(false));
        }

        [HttpGet]
        [Route("workhistory/{applicantWorkHistoryId}")]
        [ResponseType(typeof(ApplicantWorkHistoryPoco))]
        public IHttpActionResult GetApplicantWorkHistory(Guid applicantWorkHistoryId)
        {
            ApplicantWorkHistoryPoco history = _logic.Get(applicantWorkHistoryId);
            if (history == null)
            {
                return NotFound();
            }

            return Ok(history);
        }

        [HttpGet]
        [Route("workhistory")]
        [ResponseType(typeof(List<ApplicantWorkHistoryPoco>))]
        public IHttpActionResult GetAllApplicantWorkHistory()
        {
            List<ApplicantWorkHistoryPoco> historyList = _logic.GetAll();
            if (historyList == null)
            {
                return NotFound();
            }

            return Ok(historyList);
        }

        [HttpPost]
        [Route("workhistory")]
        public IHttpActionResult PostApplicantWorkHistory(ApplicantWorkHistoryPoco[] poco)
        {
            _logic.Add(poco);
            return Ok();
        }

        [HttpPut]
        [Route("workhistory")]
        public IHttpActionResult PutApplicantWorkHistory(ApplicantWorkHistoryPoco[] poco)
        {
            _logic.Update(poco);
            return Ok();
        }

        [HttpDelete]
        [Route("workhistory")]
        public IHttpActionResult DeleteApplicantWorkHistory(ApplicantWorkHistoryPoco[] poco)
        {
            _logic.Delete(poco);
            return Ok();
        }
    }
}
