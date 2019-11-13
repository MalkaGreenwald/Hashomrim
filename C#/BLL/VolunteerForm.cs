using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public static class VolunteerForm
    {

        static HashomrimProjectEntities2 db = new HashomrimProjectEntities2();
        // פונקיה זו מחזירה רשימה של מצב אישי של בנ"א לדו"ג:נשוי רווק  

        public static List<PersonalSituationDto> getListPersonalSituation()
        {
            return PersonalSituationDto.convertDBToDtoList(db.PersonalSituations.ToList());
        }
        //פונקציה זו מוסיפה מתנדב למאגר  

        public static int submit(ValunteerDto valunteerDto)
        {
            try
            {

                var val = ValunteerDto.convertDtoToDB(valunteerDto);
                if (db.Valunteers.FirstOrDefault(pp => pp.tz == val.tz) != null)
                    return 2;
                val.DetailsValunteer.silencingRingingFronDate = DateTime.Now;
                val.DetailsValunteer.silencingRingingUntilDate =DateTime.Now;
                val.DetailsValunteer.StatusValunteer = db.StatusValunteers.First();
                db.Valunteers.Add(val);
               // db.Valunteers.Add(ValunteerDto.convertDtoToDB(()valunteerDto[0]));

                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 3;
            }
           
        }

     
    }
   
}
