using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public static class MokdanLogic
    {
        static HashomrimProjectEntities2 db = new HashomrimProjectEntities2();
        //פונקציה זו מוסיפה מוקדנים למאגר
        public static int Register(MokdanDto mokdanDto)
        {
            if (checkPassword(mokdanDto.password) == 2)
                return 2;
            try
            {
                Mokdan mokdan = MokdanDto.convertDtoToDB(mokdanDto);
                db.Mokdans.Add(mokdan);
                db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
            
        }
        //  פונקציה זו בודקת אימות לסיסמא 
        private static int checkPassword(string password)
        {
            if (db.Mokdans.FirstOrDefault(f => f.password.Equals(password)) == null)
                return 1;
            return 2;
        }

       

        //  פונקציה זו בודקת האם מוקדן קיים במאגר כדי לתת לו הרשאת כניסה למערכת
        public static bool LogIn(MokdanDto mokdan)
        {
            try
            {
                if (db.Mokdans.FirstOrDefault(f => f.userName == mokdan.userName && f.password == mokdan.password) == null)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
