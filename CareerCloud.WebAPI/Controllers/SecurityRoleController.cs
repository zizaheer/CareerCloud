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
    public class SecurityRoleController : ApiController
    {
        private SecurityRoleLogic _logic;

        public SecurityRoleController()
        {
            _logic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
        }

        [HttpGet]
        [Route("role/{securityRoleId}")]
        [ResponseType(typeof(SecurityRolePoco))]
        public IHttpActionResult GetSecurityRole(Guid securityRoleId)
        {
            SecurityRolePoco role = _logic.Get(securityRoleId);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        [HttpGet]
        [Route("role")]
        [ResponseType(typeof(List<SecurityRolePoco>))]
        public IHttpActionResult GetAllSecurityRole()
        {
            List<SecurityRolePoco> roleList = _logic.GetAll();
            if (roleList == null)
            {
                return NotFound();
            }

            return Ok(roleList);
        }

        [HttpPost]
        [Route("role")]
        public IHttpActionResult PostSecurityRole(SecurityRolePoco[] poco)
        {
            _logic.Add(poco);
            return Ok();
        }

        [HttpPut]
        [Route("role")]
        public IHttpActionResult PutSecurityRole(SecurityRolePoco[] poco)
        {
            _logic.Update(poco);
            return Ok();
        }

        [HttpDelete]
        [Route("role")]
        public IHttpActionResult DeleteSecurityRole(SecurityRolePoco[] poco)
        {
            _logic.Delete(poco);
            return Ok();
        }
    }
}
