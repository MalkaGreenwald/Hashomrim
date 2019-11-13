using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public static class VolunteerIonic
    {
        static HashomrimProjectEntities2 db = new HashomrimProjectEntities2();
        //פונקציה זו בודקת מתנדב שמופיע במאגר  
        public static bool LogIn(ValunteerDto valunteer)
        {
            try
            {
                    if (db.Valunteers.FirstOrDefault(f => f.phone == valunteer.phone && f.tz == valunteer.tz) == null)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //פונקציה זו מוסיפה מתנדב חדש למאגר  
        public static int Register(ValunteerDto valunteerDto)
        {
            try
            {
                Valunteer valunteer = ValunteerDto.convertDtoToDB(valunteerDto);
                //להכניס את פרטי העיר
                Valunteer v = db.Valunteers.FirstOrDefault(f => f.tz == valunteer.tz);
                 if (v!=null)
                    return 3;
                if (valunteer.tz.Equals('0') || valunteer.firstName.Equals('0') || valunteer.lastName.Equals('0') || valunteer.phone.Equals('0'))
                    return 0;
               
                valunteer.PersonalSituation = db.PersonalSituations.First(p => p.personalSituationId == valunteer.personalSituationId);
                valunteer.DetailsValunteer = new DetailsValunteer();
                valunteer.DetailsValunteer.statusValunteerId = db.StatusValunteers.FirstOrDefault(p => p.discribeStatusValunteer == "פעיל").statusValunteerId;
                valunteer.DetailsValunteer.silencingRingingFronDate = DateTime.Now;
                valunteer.DetailsValunteer.silencingRingingUntilDate = DateTime.Now;
                db.Valunteers.Add(valunteer);
                db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        //פונקציה זו משתיקה הודעות למתנדב מסוים 
        public static bool silentNotification(string valunteerTz)
        {

            try
            {
                int idVolunteer = db.Valunteers.FirstOrDefault(f => f.tz == valunteerTz).id;
                HistoryStatusValunteer historyStatusValunteer = new HistoryStatusValunteer();
                historyStatusValunteer.volunteerId = idVolunteer;
                historyStatusValunteer.silencingRingingFromDate = DateTime.Now;
                historyStatusValunteer.silencingRingingUntilDate = DateTime.Now.AddHours(24);
                historyStatusValunteer.statusValunteerId= db.StatusValunteers.FirstOrDefault(f => f.discribeStatusValunteer == "לא פעיל").statusValunteerId;
                db.HistoryStatusValunteers.Add(historyStatusValunteer);


               DetailsValunteer detailsValunteer = db.Valunteers.FirstOrDefault(f => f.tz == valunteerTz).DetailsValunteer;
                var st = db.StatusValunteers.FirstOrDefault(f => f.discribeStatusValunteer == "לא פעיל");
                if(st!=null)
                detailsValunteer.StatusValunteer = st;
                detailsValunteer.silencingRingingFronDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        //פונקציה זו מפעילה הודעות למתנדב מסוים 
        //public static bool ringNotification(string valunteerTz)
        //{
        //    try
        //    {
        //        int idVolunteer = db.Valunteers.FirstOrDefault(f => f.tz == valunteerTz).id;
        //        HistoryStatusValunteer historyStatusValunteer = db.HistoryStatusValunteers.FirstOrDefault(f => f.volunteerId == idVolunteer&&
        //        f.silencingRingingUntilDate.Hour-f.silencingRingingFromDate.Hour == 0&&
        //        f.silencingRingingUntilDate.Second - f.silencingRingingFromDate.Second == 0&&
        //        f.silencingRingingUntilDate.Minute - f.silencingRingingFromDate.Minute == 0&&
        //        f.silencingRingingUntilDate.Millisecond - f.silencingRingingFromDate.Millisecond == 0);
        //        if(historyStatusValunteer!=null)
        //        historyStatusValunteer.silencingRingingUntilDate= DateTime.Now;
        //        DetailsValunteer detailsValunteer = db.Valunteers.FirstOrDefault(f => f.tz == valunteerTz).DetailsValunteer;
        //        detailsValunteer.statusValunteerId = db.StatusValunteers.FirstOrDefault(f => f.discribeStatusValunteer == "פעיל").statusValunteerId;
        //        detailsValunteer.silencingRingingUntilDate = historyStatusValunteer.silencingRingingUntilDate;
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        public static bool ringNotification(string valunteerTz)
        {
            try
            {
                int idVolunteer = db.Valunteers.FirstOrDefault(f => f.tz == valunteerTz).id;
                HistoryStatusValunteer historyStatusValunteer = db.HistoryStatusValunteers.FirstOrDefault(f => f.volunteerId == idVolunteer);
                if (historyStatusValunteer != null)
                    historyStatusValunteer.silencingRingingUntilDate = DateTime.Now;
                DetailsValunteer detailsValunteer = db.Valunteers.FirstOrDefault(f => f.tz == valunteerTz).DetailsValunteer;
                detailsValunteer.statusValunteerId = db.StatusValunteers.FirstOrDefault(f => f.discribeStatusValunteer == "פעיל").statusValunteerId;
                detailsValunteer.silencingRingingUntilDate = historyStatusValunteer.silencingRingingUntilDate;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //פונקציה זו מחזירה את פרטי המנדב לפי ת.ז
        public static ValunteerDto getDetailsVolunteer(string volunteerTz)
        {
            Valunteer valunteer = db.Valunteers.FirstOrDefault(f => f.tz == volunteerTz);
            //valunteer.DetailsValunteer = db.DetailsValunteers.FirstOrDefault(f => f. == valunteer.id);
            return DTO.ValunteerDto.convertDBToDto(valunteer);
        }
        // פונקיה זו מחזירה רשימה של מצב אישי של בנ"א לדו"ג:נשוי רווק  
        public static List<PersonalSituationDto> getListStatusPersonal()
        {
            List<PersonalSituation> l = new List<PersonalSituation>();
            l = db.PersonalSituations.ToList();
            return PersonalSituationDto.convertDBToDtoList(l);
        }
    }
}
