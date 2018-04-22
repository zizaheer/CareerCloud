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
    public class SecurityLoginController : ApiController
    {
        private SecurityLoginLogic _logic;

        public SecurityLoginController()
        {
            _logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
        }

        [HttpGet]
        [Route("login/{securityLoginId}")]
        [ResponseType(typeof(SecurityLoginPoco))]
        public IHttpActionResult GetSecurityLogin(Guid securityLoginId)
        {
            SecurityLoginPoco login = _logic.Get(securityLoginId);
            if (login == null)
            {
                return NotFound();
            }

            return Ok(login);
        }

        [HttpGet]
        [Route("login")]
        [ResponseType(typeof(List<SecurityLoginPoco>))]
        public IHttpActionResult GetAllSecurityLogin()
        {
            List<SecurityLoginPoco> loginList = _logic.GetAll();
            if (loginList == null)
            {
                return NotFound();
            }

            return Ok(loginList);
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult PostSecurityLogin(SecurityLoginPoco[] poco)
        {
            _logic.Add(poco);
            return Ok();
        }

        [HttpPut]
        [Route("login")]
        public IHttpActionResult PutSecurityLogin(SecurityLoginPoco[] poco)
        {
            _logic.Update(poco);
            return Ok();
        }

        [HttpDelete]
        [Route("login")]
        public IHttpActionResult DeleteSecurityLogin(SecurityLoginPoco[] poco)
        {
            _logic.Delete(poco);
            return Ok();
        }
    }
}
