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
    public class SecurityLoginsRoleController : ApiController
    {
        private SecurityLoginsRoleLogic _logic;

        public SecurityLoginsRoleController()
        {
            _logic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
        }

        [HttpGet]
        [Route("loginrole/{securityLoginsRoleId}")]
        [ResponseType(typeof(SecurityLoginsRolePoco))]
        public IHttpActionResult GetSecurityLoginsRole(Guid securityLoginsRoleId)
        {
            SecurityLoginsRolePoco loginsRole = _logic.Get(securityLoginsRoleId);
            if (loginsRole == null)
            {
                return NotFound();
            }

            return Ok(loginsRole);
        }

        [HttpGet]
        [Route("loginrole")]
        [ResponseType(typeof(List<SecurityLoginsRolePoco>))]
        public IHttpActionResult GetAllSecurityLoginsRole()
        {
            List<SecurityLoginsRolePoco> loginRoleList = _logic.GetAll();
            if (loginRoleList == null)
            {
                return NotFound();
            }

            return Ok(loginRoleList);
        }

        [HttpPost]
        [Route("loginrole")]
        public IHttpActionResult PostSecurityLoginRole(SecurityLoginsRolePoco[] poco)
        {
            _logic.Add(poco);
            return Ok();
        }

        [HttpPut]
        [Route("loginrole")]
        public IHttpActionResult PutSecurityLoginsRole(SecurityLoginsRolePoco[] poco)
        {
            _logic.Update(poco);
            return Ok();
        }

        [HttpDelete]
        [Route("loginrole")]
        public IHttpActionResult DeleteSecurityLoginRole(SecurityLoginsRolePoco[] poco)
        {
            _logic.Delete(poco);
            return Ok();
        }
    }
}
