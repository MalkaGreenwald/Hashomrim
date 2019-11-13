using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public static class EventForm
    {

        static HashomrimProjectEntities2 db = new HashomrimProjectEntities2();
        //פונקציה זו מחזירה רשימה של שם לאירוע לדו"ג :גניבה    
        public static List<EventNameDto> getListNameEvent()
         {
            HashomrimProjectEntities2 db2 = new HashomrimProjectEntities2();
            return EventNameDto.convertDBToDtoList(db2.EventNames.ToList());
         }
        //פונקציה זו מחזירה רשימה של מצב אירוע לדו"ג פעיל הוזנק    
        public static List<EventStatusDto> getListStatusEvent()
        {
            List<EventStatu> l = new List<EventStatu>();
            l = db.EventStatus.ToList();
            return EventStatusDto.convertDBToDtoList(l);
        }
        //פונקציה זו מוסיפה אירוע חדש למאגר

        public static bool submit(EventsDto eventsDto)
        {
            //    db.EventName.FirstOrDefault(f => f.eventNameId ==eventsDto.eventNameId);
            try
            {
                eventsDto.startCallingDate = DateTime.Now;
                eventsDto.eventStatusId = 1;
                Event e = EventsDto.convertDtoToDB(eventsDto);
              //  e.EventStatu = db.EventStatus.First(p => p.eventStatusId == e.eventStatusId);
                db.Events.Add(e);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
    }
}
