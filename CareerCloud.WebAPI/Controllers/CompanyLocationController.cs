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
    [RoutePrefix("api/careercloud/company/v1")]
    public class CompanyLocationController : ApiController
    {
        private CompanyLocationLogic _logic;

        public CompanyLocationController()
        {
            _logic = new CompanyLocationLogic(new EFGenericRepository<CompanyLocationPoco>(false));
        }

        [HttpGet]
        [Route("location/{companyLocationId}")]
        [ResponseType(typeof(CompanyLocationPoco))]
        public IHttpActionResult GetCompanyLocation(Guid companyLocationId)
        {
            CompanyLocationPoco location = _logic.Get(companyLocationId);
            if (location == null)
            {
                return NotFound();
            }
          
            return Ok(location);
        }

        [HttpGet]
        [Route("location")]
        [ResponseType(typeof(List<CompanyLocationPoco>))]
        public IHttpActionResult GetAllCompanyLocation()
        {
            List<CompanyLocationPoco> locList = _logic.GetAll();
            if (locList == null)
            {
                return NotFound();
            }

            return Ok(locList);
        }

        [HttpPost]
        [Route("location")]
        public IHttpActionResult PostCompanyLocation(CompanyLocationPoco[] poco)
        {
            _logic.Add(poco);
            return Ok();
        }

        [HttpPut]
        [Route("location")]
        public IHttpActionResult PutCompanyLocation(CompanyLocationPoco[] poco)
        {
            _logic.Update(poco);
            return Ok();
        }

        [HttpDelete]
        [Route("location")]
        public IHttpActionResult DeleteCompanyLocation(CompanyLocationPoco[] poco)
        {
            _logic.Delete(poco);
            return Ok();
        }
    }
}
