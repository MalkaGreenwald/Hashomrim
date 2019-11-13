using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using DTO;

namespace test.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/VolunteerForm")]
    public class VolunteerFormController : ApiController
    {
        [Route("getListPersonalSituation")]
        [HttpGet]
        // פונקיה זו מחזירה רשימה של מצב אישי של בנ"א לדו"ג:נשוי רווק  
        public List<PersonalSituationDto> getListPersonalSituation()
        {
            return BLL.VolunteerForm.getListPersonalSituation();
        }


        [Route("submit")]
        [HttpPost]
        //פונקציה זו מוסיפה מתנדב למאגר  
        public int submit(ValunteerDto valunteerDto)
        {
            return BLL.VolunteerForm.submit(valunteerDto) ;
        }


        
    }
}