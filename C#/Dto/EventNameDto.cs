using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DTO
{
    public class EventNameDto
    {
        public int eventNameId { get; set; }
        public string discribeEventName { get; set; }   
        public  List<EventsDto> Events { get; set; }
        public static EventNameDto convertDBToDto(EventName eventName)
        {
            return new EventNameDto()
            {
               discribeEventName=eventName.discribeEventName,
               eventNameId=eventName.eventNameId
            };
        }
       
        public static List<EventNameDto> convertDBToDtoList(List<EventName> eventNameList)
        {
           
                //פונקציה זו מקבלת אוסף מסוג מחלקה שנוצרה במודל של מיקרוסופט
                //שלנו DTOוממירה אותה לאוסף מסוג מחלקת 
                List<EventNameDto> l = new List<EventNameDto>();
            //לולאה זו סורקת את האוסף שהתקבל ושולחת כל איבר באוסף לפונקציית המרה למחלקה משלי ואת התוצאה מוסיפה לאוסף החדש
            eventNameList.ForEach(a => l.Add(convertDBToDto(a)));
                return l;
            
        }
        public static EventName convertDtoToDB(EventNameDto eventNameDto)
        {
            return new EventName()
            {
                discribeEventName = eventNameDto.discribeEventName,
                eventNameId = eventNameDto.eventNameId
            };
        }
    }
}
