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
    [RoutePrefix("api/EventForm")]
    public class EventFormController : ApiController
    {
        [Route("getListNameEvent")]
        [HttpGet]
        //פונקציה זו מחזירה רשימה של שם לאירוע לדו"ג :גניבה    
        public List<EventNameDto>  getListNameEvent()
        {
            return BLL.EventForm.getListNameEvent();
        }



        [Route("getListStatusEvent")]
        [HttpGet]
        //פונקציה זו מחזירה רשימה של מצב אירוע לדו"ג פעיל הוזנק    
        public List<EventStatusDto> getListStatusEvent()
        {
            return BLL.EventForm.getListStatusEvent();
        }


        [Route("submit")]
        [HttpPost]
        //פונקציה זו מוסיפה אירוע חדש למאגר
        public int submit([FromBody]EventsDto eventsDto)
        {
            return BLL.EventForm.submit(eventsDto) ?1:0;
        }





    }
}