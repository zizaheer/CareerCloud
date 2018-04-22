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
    public class ApplicantSkillController : ApiController
    {
        private ApplicantSkillLogic _logic;

        public ApplicantSkillController()
        {
            _logic = new ApplicantSkillLogic(new EFGenericRepository<ApplicantSkillPoco>(false));
        }

        [HttpGet]
        [Route("skill/{applicantSkillId}")]
        [ResponseType(typeof(ApplicantSkillPoco))]
        public IHttpActionResult GetApplicantSkill(Guid applicantSkillId)
        {
            ApplicantSkillPoco skill = _logic.Get(applicantSkillId);
            if (skill == null)
            {
                return NotFound();
            }

            return Ok(skill);
        }

        [HttpGet]
        [Route("skill")]
        [ResponseType(typeof(List<ApplicantSkillPoco>))]
        public IHttpActionResult GetAllApplicantSkill()
        {
            List<ApplicantSkillPoco> skillList = _logic.GetAll();
            if (skillList == null)
            {
                return NotFound();
            }

            return Ok(skillList);
        }

        [HttpPost]
        [Route("skill")]
        public IHttpActionResult PostApplicantSkill(ApplicantSkillPoco[] poco)
        {
            _logic.Add(poco);
            return Ok();
        }

        [HttpPut]
        [Route("skill")]
        public IHttpActionResult PutApplicantSkill(ApplicantSkillPoco[] poco)
        {
            _logic.Update(poco);
            return Ok();
        }

        [HttpDelete]
        [Route("skill")]
        public IHttpActionResult DeleteApplicantSkill(ApplicantSkillPoco[] poco)
        {
            _logic.Delete(poco);
            return Ok();
        }
    }
}
