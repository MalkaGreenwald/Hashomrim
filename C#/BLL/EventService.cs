using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Device.Location;

namespace BLL
{
    public static class EventService
    {
        public static HashomrimProjectEntities2 db = new HashomrimProjectEntities2();

        public static List<EventsDto> listEvent()
        {
            try
            {

                //      return EventsDto.convertDBToDtoList(db.Events.Where(w => w.eventStatusId != db.EventStatus.FirstOrDefault(f=> f.discribeEventStatus=="הסתיים"|| f.discribeEventStatus=="מבוטל").eventStatusId).ToList());
                var list = EventsDto.convertDBToDtoList(db.Events.Where(w => w.eventStatusId != 3 && w.eventStatusId != 4).ToList());
              
                return list;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool eventFinish(int eventCode)
        {
            try
            {
                //לעשות == או equals
                db.Events.FirstOrDefault(w => w.eventCode == eventCode).eventStatusId = db.EventStatus.FirstOrDefault(f => f.discribeEventStatus == "הסתיים").eventStatusId;

                db.SaveChanges();
                return true;
                //להעביר לטבלת היסטוריה
            }
            catch (Exception)
            {
                return false;

            }
        }

        public static List<EventsDto> eventByDistance(int userTz, double lat, double lon)
        {
            try
            {
                var listEvent = db.Events.Where(p => p.startCallingDate.AddMinutes(1) >= DateTime.Now).ToList();
                var listResult = new List<EventsDto>();
                var user = db.Valunteers.First(p => p.tz == userTz.ToString());

                foreach (var item in listEvent)
                {
                    double latA = item.widthPointAddress;
                    double longA = item.heightPointAddress;
                    var locA = new GeoCoordinate(latA, longA);
                    var locB = new GeoCoordinate(lat, lon);
                    double distance = locA.GetDistanceTo(locB);
                    if (distance <= user.cityId && user.DetailsValunteer.StatusValunteer.statusValunteerId == 1)
                        listResult.Add(EventsDto.convertDBToDto(item));
                }
                return listResult;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static bool eventMore(int eventCode)
        {
            try
            {
                db.Events.FirstOrDefault(f => f.eventCode == eventCode).startCallingDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
