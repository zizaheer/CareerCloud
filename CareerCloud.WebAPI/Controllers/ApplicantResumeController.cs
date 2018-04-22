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
    public class ApplicantResumeController : ApiController
    {
        private ApplicantResumeLogic _logic;

        public ApplicantResumeController()
        {
            _logic = new ApplicantResumeLogic(new EFGenericRepository<ApplicantResumePoco>(false));
        }

        [HttpGet]
        [Route("resume/{applicantResumeId}")]
        [ResponseType(typeof(ApplicantResumePoco))]
        public IHttpActionResult GetApplicantResume(Guid applicantResumeId)
        {
            ApplicantResumePoco resume = _logic.Get(applicantResumeId);
            if (resume == null)
            {
                return NotFound();
            }

            return Ok(resume);
        }

        [HttpGet]
        [Route("resume")]
        [ResponseType(typeof(List<ApplicantResumePoco>))]
        public IHttpActionResult GetAllApplicantResume()
        {
            List<ApplicantResumePoco> resumeList = _logic.GetAll();
            if (resumeList == null)
            {
                return NotFound();
            }

            return Ok(resumeList);
        }

        [HttpPost]
        [Route("resume")]
        public IHttpActionResult PostApplicantResume(ApplicantResumePoco[] poco)
        {
            _logic.Add(poco);
            return Ok();
        }

        [HttpPut]
        [Route("resume")]
        public IHttpActionResult PutApplicantResume(ApplicantResumePoco[] poco)
        {
            _logic.Update(poco);
            return Ok();
        }

        [HttpDelete]
        [Route("resume")]
        public IHttpActionResult DeleteApplicantResume(ApplicantResumePoco[] poco)
        {
            _logic.Delete(poco);
            return Ok();
        }
    }
}
