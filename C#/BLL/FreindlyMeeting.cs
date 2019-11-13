using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{

    public class FreindlyMeeting
    {
        static List<string> tzPeople = new List<string>();
        static HashomrimProjectEntities2 db = new HashomrimProjectEntities2();
        //פונקציה זו מחזירה את כל המפגשים החברתיים
        public static List<FreindlyEventDto> getListFmeeting()
        {
            return FreindlyEventDto.convertDBToDtoList(db.FreindlyEvents.ToList());
        }

        //פונקציה זו רושמת מתנדב שמאשר הגעה למפגש
        public static bool takeFMeeting(string volunteerTz, int friendMeetingCode)
        {
            try
            {
                if(tzPeople.Contains(volunteerTz))
                {
                    return false;
                }
                tzPeople.Add(volunteerTz);
                db.FreindlyEvents.FirstOrDefault(f => f.freindlyCode == friendMeetingCode).countValunteer++;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //פונקציה זו מוסיפה מפגשים חברתים למאגר 
        public static Boolean submit(FreindlyEventDto Freindly)
        {
            try
            {
                Freindly.countValunteer = 0;
             FreindlyEvent f=FreindlyEventDto.convertDtoToDB((FreindlyEventDto)Freindly);
                db.FreindlyEvents.Add(f);
                // db.Valunteers.Add(ValunteerDto.convertDtoToDB(()valunteerDto[0]));

                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        //מחזירה את פרטי המתנדב המצטיין
        //public static ValunteerDto excellent()
        //{
        //    db.ValunteerEvents.GroupBy(g => g.valunteerId).Count();
           
        //    return;

        //}
    }
}
