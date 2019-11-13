using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace test.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Event")]
        public class EventController : ApiController
    {
     // 
        [Route("listEvent")]
        [HttpGet]
        //פונקציה זו מחזירה רשימה של כל האירועים 
        public List<EventsDto>  listEvent()
        {
            return BLL.EventService.listEvent();
        }
        [Route("eventFinish")]
        [HttpGet]
        //פונקציה זו מעבירה אירוע לסטטוס הסתיים
        public int eventFinish(int eventCode)
        {
            return BLL.EventService.eventFinish(eventCode) ? 1 : 0;

        }
        
        [Route("eventMore")]
        [HttpGet]
        public int eventMore(int eventCode)
        {
             return BLL.EventService.eventMore(eventCode) ? 1 : 0;

        }
        [Route("eventByDistance/{userTz}/{lat}/{lon}")]
        [HttpGet]
        public List<EventsDto> eventByDistance(int userTz, double lat, double lon)
        {
            return BLL.EventService.eventByDistance(userTz,lat,lon);

        }
    }
}
