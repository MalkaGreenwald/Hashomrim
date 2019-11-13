using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DTO
{
   public class CallingDto
    {
        HashomrimProjectEntities2 db = new HashomrimProjectEntities2();
        public int callingCode { get; set; }
        public int eventCodeId { get; set; }
        public System.DateTime callingDate { get; set; }
        //  ומה לעשות עם list לשאול את חיה מה זה אין אותו במחלקה
        public EventsDto eventsDto;
        public static CallingDto convertDBToDto(Callling callling)
        {
            return new CallingDto()
            {
               callingCode=callling.callingCode,
               callingDate=callling.callingDate,
               eventCodeId=callling.eventCodeId
            };
        }
        public static Callling convertDtoToDB(CallingDto calllingDto)
        {
            return new Callling()
            {
                callingCode = calllingDto.callingCode,
                callingDate = calllingDto.callingDate,
                eventCodeId = calllingDto.eventCodeId
            };
        }
    }
}
