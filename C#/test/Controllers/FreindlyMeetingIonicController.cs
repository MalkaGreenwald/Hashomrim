using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using DTO;
namespace test.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [System.Web.Http.RoutePrefix("api/FreindlyMeetingIonic")]
    public class FreindlyMeetingIonicController : ApiController
    {
        // GET: FreindlyMeetingIonic
      
        [System.Web.Http.Route("getListFmeeting")]
        [System.Web.Http.HttpGet]
        //פונקציה זו מחזירה את כל המפגשים החברתיים
        public List<FreindlyEventDto> getListFmeeting()
        {
            return BLL.FreindlyMeeting.getListFmeeting() ;
        }


        [System.Web.Http.Route("takeFMeeting")]
        [System.Web.Http.HttpGet]
        //פונקציה זו רושמת מתנדב שמאשר הגעה למפגש
        public int takeFMeeting(string VolunteerTz, int friendMeetingCode)
        {
            return BLL.FreindlyMeeting.takeFMeeting(VolunteerTz, friendMeetingCode) ? 1 : 0;
        }
 
    }
}