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
    public class SystemLanguageCodeController : ApiController
    {
        private SystemLanguageCodeLogic _logic;

        public SystemLanguageCodeController()
        {
            _logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
        }

        [HttpGet]
        [Route("language/{systemLanguageCode}")]
        [ResponseType(typeof(SystemLanguageCodePoco))]
        public IHttpActionResult GetSystemLanguageCode(string systemLanguageCode)
        {
            SystemLanguageCodePoco lang = _logic.Get(systemLanguageCode);
            if (lang == null)
            {
                return NotFound();
            }

            return Ok(lang);
        }

        [HttpGet]
        [Route("language")]
        [ResponseType(typeof(List<SystemLanguageCodePoco>))]
        public IHttpActionResult GetAllSystemLanguageCode()
        {
            List<SystemLanguageCodePoco> langList = _logic.GetAll();
            if (langList == null)
            {
                return NotFound();
            }

            return Ok(langList);
        }

        [HttpPost]
        [Route("language")]
        public IHttpActionResult PostSystemLanguageCode(SystemLanguageCodePoco[] poco)
        {
            _logic.Add(poco);
            return Ok();
        }

        [HttpPut]
        [Route("language")]
        public IHttpActionResult PutSystemLanguageCode(SystemLanguageCodePoco[] poco)
        {
            _logic.Update(poco);
            return Ok();
        }

        [HttpDelete]
        [Route("language")]
        public IHttpActionResult DeleteSystemLanguageCode(SystemLanguageCodePoco[] poco)
        {
            _logic.Delete(poco);
            return Ok();
        }
    }
}
