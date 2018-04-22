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
    [RoutePrefix("api/careercloud/security/v1")]
    public class SecurityLoginsLogController : ApiController
    {
        private SecurityLoginsLogLogic _logic;

        public SecurityLoginsLogController()
        {
            _logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
        }

        [HttpGet]
        [Route("loginlog/{securityLoginsLogId}")]
        [ResponseType(typeof(SecurityLoginsLogPoco))]
        public IHttpActionResult GetSecurityLoginLog(Guid securityLoginsLogId)
        {
            SecurityLoginsLogPoco loginsLog = _logic.Get(securityLoginsLogId);
            if (loginsLog == null)
            {
                return NotFound();
            }

            return Ok(loginsLog);
        }

        [HttpGet]
        [Route("loginlog")]
        [ResponseType(typeof(List<SecurityLoginsLogPoco>))]
        public IHttpActionResult GetAllSecurityLoginsLog()
        {
            List<SecurityLoginsLogPoco> logList = _logic.GetAll();
            if (logList == null)
            {
                return NotFound();
            }

            return Ok(logList);
        }

        [HttpPost]
        [Route("loginlog")]
        public IHttpActionResult PostSecurityLoginLog(SecurityLoginsLogPoco[] poco)
        {
            _logic.Add(poco);
            return Ok();
        }

        [HttpPut]
        [Route("loginlog")]
        public IHttpActionResult PutSecurityLoginLog(SecurityLoginsLogPoco[] poco)
        {
            _logic.Update(poco);
            return Ok();
        }

        [HttpDelete]
        [Route("loginlog")]
        public IHttpActionResult DeleteSecurityLoginLog(SecurityLoginsLogPoco[] poco)
        {
            _logic.Delete(poco);
            return Ok();
        }
    }
}
