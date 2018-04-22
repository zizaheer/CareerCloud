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
    [RoutePrefix("api/careercloud/system/v1")]
    public class SystemCountryCodeController : ApiController
    {
        private SystemCountryCodeLogic _logic;

        public SystemCountryCodeController()
        {
            _logic = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
        }

        [HttpGet]
        [Route("country/{systemCountryCode}")]
        [ResponseType(typeof(SystemCountryCodePoco))]
        public IHttpActionResult GetSystemCountryCode(string systemCountryCode)
        {
            SystemCountryCodePoco country = _logic.Get(systemCountryCode);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpGet]
        [Route("country")]
        [ResponseType(typeof(List<SystemCountryCodePoco>))]
        public IHttpActionResult GetAllSystemCountryCode()
        {
            List<SystemCountryCodePoco> countryList = _logic.GetAll();
            if (countryList == null)
            {
                return NotFound();
            }

            return Ok(countryList);
        }

        [HttpPost]
        [Route("country")]
        public IHttpActionResult PostSystemCountryCode(SystemCountryCodePoco[] poco)
        {
            _logic.Add(poco);
            return Ok();
        }

        [HttpPut]
        [Route("country")]
        public IHttpActionResult PutSystemCountryCode(SystemCountryCodePoco[] poco)
        {
            _logic.Update(poco);
            return Ok();
        }

        [HttpDelete]
        [Route("country")]
        public IHttpActionResult DeleteSystemCountryCode(SystemCountryCodePoco[] poco)
        {
            _logic.Delete(poco);
            return Ok();
        }
    }
}
