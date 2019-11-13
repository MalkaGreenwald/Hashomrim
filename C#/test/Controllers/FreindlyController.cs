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
    [RoutePrefix("api/Freindly")]
    public class FreindlyController : ApiController
    {
        [Route("submit")]
        [HttpPost]
        //פונקציה זו מוסיפה מפגשים חברתים למאגר 
        public int submit(DTO.FreindlyEventDto Freindly)
        {
             return BLL.FreindlyMeeting.submit(Freindly) ? 1 : 0;
        }
    }
}
