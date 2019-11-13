using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public static class EventIonic
    {
        static HashomrimProjectEntities2 db = new HashomrimProjectEntities2();
        // פונקציה זו מחזירה רשימה של כל האירועים   
        public static List<EventsDto>listEvent()
        {
            return EventsDto.convertDBToDtoList(db.Events.ToList());
        }
        //פונקציה זו רושמת מתנדב שמאשר יציאה לאירע 
        public static bool takeEvent(string valunteerTz, int eventCode)
        {
            try
            {
                var valen = db.Valunteers.First(p => p.tz == valunteerTz);
                ValunteerEvent valunteerEvent = new ValunteerEvent();
                valunteerEvent.eventCodeId = eventCode;
                valunteerEvent.ValunteerStatusInEvent = db.ValunteerStatusInEvents.FirstOrDefault(f => f.discribeValunteerStatusInEvent.Equals("יצא לאירוע"));
                valunteerEvent.dateGetEvent = DateTime.Now;
                valunteerEvent.valunteerId = valen.id;
                db.ValunteerEvents.Add(valunteerEvent);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        //פונקציה זו בודקת האם מתנדב מסוים יצא לאירוע מסוים    
        public static bool checkEvent(string volunteerTz, int eventCode)
        {
            try
            {
                var val = db.Valunteers.First(p => p.tz == volunteerTz);
             ValunteerEvent v =db.ValunteerEvents.FirstOrDefault(f => f.eventCodeId == eventCode && f.valunteerId == val.id);
            if (v != null)
                return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public static bool option(string valunteerTz, int num)
        {
            try
            {
                Valunteer valen = db.Valunteers.First(p => p.tz == valunteerTz);
                valen.cityId = num;
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
