using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace test.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Main")]
    public class MainController : ApiController
    {
       
        [Route("listValonteer")]
        [HttpGet]
       // קבלת כל המתנדבים באירוע 
         public List<ValunteerDto> listValonteer()

        {
            return BLL.Main.listValonteer();
        }
        //  מחזיר פרטי מתנדב מסוים לפי ת.ז
        [Route("detailVolunteer")]
        [HttpGet]
        public ValunteerDto detailVolunteer(string tzVolunteer)
        {
            return BLL.Main.detailVolunteer(tzVolunteer);
        }
        
        //הרשמת מתנדב מחזירה האם נרשם בהצלחה או לא
        [Route("registerVolunteer")]
        [HttpGet]
        public int registerVolunteer(string tzVolunteer)
        {
            return BLL.Main.registerVolunteer(tzVolunteer)?1:0;
        }
        [Route("open")]
        [HttpGet]
        public int open(string password, string name)
        {
            return BLL.Main.open(password, name);
        }
    }
}