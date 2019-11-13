using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class Main
    {
        public static HashomrimProjectEntities2 db = new HashomrimProjectEntities2();
        // קבלת כל המתנדבים באירוע 
        public static List<ValunteerDto> listValonteer()
        {

            return ValunteerDto.convertDBToDtoList(db.Valunteers.Where(w=>w.DetailsValunteer.statusValunteerId==3).ToList());
             //במקום המס 3 בשאילתה (db.StatusValunteer.FirstOrDefault(g => g.discribeStatusValunteer == "מושהה").statusValunteerId)
        }


        //  מחזיר פרטי מתנדב מסוים לפי ת.ז
        public static ValunteerDto detailVolunteer(string tzVolunteer)
        {
          if (tzVolunteer!="0")
            return ValunteerDto.convertDBToDto(db.Valunteers.FirstOrDefault(f => f.tz == tzVolunteer));
            return null;
        }
        //הרשמת מתנדב מחזירה האם נרשם בהצלחה או לא
        public static bool registerVolunteer(string tzVolunteer)
        {

            try
            {
                db.Valunteers.FirstOrDefault(f => f.tz == tzVolunteer).DetailsValunteer.statusValunteerId = 1;
                db.SaveChanges();
                  return true;
            }
            catch (Exception)
            {

                return false;
            }           
        }

        public static int open(string password, string name)
        {
            try
            {
                if (db.Mokdans.FirstOrDefault(f => f.password == password && f.userName == name) == null)
                    return 3;
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }
    }
}
