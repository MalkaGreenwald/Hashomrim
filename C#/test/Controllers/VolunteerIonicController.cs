using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DTO;
namespace test.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/VolunteerIonic")]
    public class VolunteerIonicController : ApiController
    {
        // פונקציות אלו עוברות דרך האפליקציה
        //בודקת האם האם המתנדב קיים מחזירה 1 או 0 
        [Route("login")]
        [HttpPost]
        public int Login([FromBody]ValunteerDto valunteer)
        {
            return BLL.VolunteerIonic.LogIn(valunteer) ? 1 : 0;
        }
        //מקבלת פרטי מתנדב ורושמת אותו למערכת 
        [Route("register")]
        [HttpPost]
        public int Register([FromBody]ValunteerDto Valunteer)
        {
            return BLL.VolunteerIonic.Register(Valunteer);
        }
        [Route("listStatus")]
        [HttpGet]
        // פונקיה זו מחזירה רשימה של מצב אישי של בנ"א לדו"ג:נשוי רווק  
        public List<PersonalSituationDto> listStatus()
        {
            return BLL.VolunteerIonic.getListStatusPersonal();
        }
        
        [Route("silentNotification")]
        [HttpPost]
        //פונקציה זו משתיקה הודעות למתנדב מסוים 

        public int silentNotification([FromBody]ValunteerDto valunteerDto)
        {
            return BLL.VolunteerIonic.silentNotification(valunteerDto.tz)?1:0;
        }

        [Route("ringNotification")]
        [HttpPost]
        //פונקציה זו מפעילה הודעות למתנדב מסוים 

        public int ringNotification([FromBody]ValunteerDto valunteerDto)
        {
             return BLL.VolunteerIonic.ringNotification(valunteerDto.tz) ? 1 : 0;
        }
        [Route("getDetailsVolunteer")]
        [HttpGet]
        //פונקציה זו מחזירה את פרטי המנדב לפי ת.ז
        public ValunteerDto getDetailsVolunteer(string volunteerTz)
        {
            return BLL.VolunteerIonic.getDetailsVolunteer(volunteerTz);
        }

    }
}
