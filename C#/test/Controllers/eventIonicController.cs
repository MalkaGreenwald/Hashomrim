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
    [RoutePrefix("api/EventIonic")]
    public class eventIonicController : ApiController
    {
        [Route("listEvent")]
        [HttpGet]
        // פונקציה זו מחזירה רשימה של כל האירועים   
        public List<EventsDto> listEvent()
        {
            return BLL.EventIonic.listEvent();
        }
 
        [Route("takeEvent")]
        [HttpGet]
        //פונקציה זו רושמת מתנדב שמאשר יציאה לאירע 
        public int takeEvent(string VolunteerTz, int  eventCode)
        {
          return BLL.EventIonic.takeEvent(VolunteerTz, eventCode) ?1:0;
        }
        [Route("checkEvent")]
        [HttpGet]
        //פונקציה זו בודקת האם מתנדב מסוים יצא לאירוע מסוים    
        public int checkEvent(string VolunteerTz, int eventCode)
        {
            return BLL.EventIonic.checkEvent(VolunteerTz, eventCode) ? 1 : 0;
        }
        [Route("option")]
        [HttpGet]
        //פונקציה מגידרה מרחק קבלת התראות למתנדב
        public int option(string VolunteerTz, int num)
        {
            return BLL.EventIonic.option(VolunteerTz, num) ? 1 : 0;
        }
    }
}
