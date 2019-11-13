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
    [RoutePrefix("api/mokdan")]
    public class MokdanController : ApiController
    {
       

        [Route("login")]
        [HttpPost]
        //  פונקציה זו בודקת האם מוקדן קיים במאגר כדי לתת לו הרשאת כניסה למערכת
        public int Login([FromBody]MokdanDto mokdan)
        {
            return BLL.MokdanLogic.LogIn(mokdan) ? 1 : 0;
        }

        [Route("register")]
        [HttpPost]
        //פונקציה זו מוסיפה מוקדנים למאגר
        public int Register([FromBody]MokdanDto mokdan)
        {
            return BLL.MokdanLogic.Register(mokdan);
        }
        [Route("detailVolunteer/{tzVolunteer}")]
        [HttpGet]
        //פונקציה זו מחזירה את פרטי המנדב לפי ת.ז
        public ValunteerDto detailVolunteer(string tzVolunteer)
        {
            return BLL.Main.detailVolunteer(tzVolunteer);
        }
    }
}
