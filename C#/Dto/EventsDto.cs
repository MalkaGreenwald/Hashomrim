using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DTO
{
   public class EventsDto
    {
        
        public int eventCode { get; set; }
        public Nullable<int> eventNameId { get; set; }
        public string eventName { get; set; }
        public string eventDescription { get; set; }
        public double heightPointAddress { get; set; }
        public double widthPointAddress { get; set; }
        public System.DateTime startCallingDate { get; set; }
        public int eventStatusId { get; set; }
        public string stringAddress { get; set; }
        public int count { get; set; }
        public  List<ValunteerEventDto> ValunteerEvent { get; set; }

        public static EventsDto convertDBToDto(DAL.Event events)
        {
            return new EventsDto()
            {
                eventCode = events.eventCode,
                eventDescription = events.eventDescription,
                eventNameId = events.eventNameId,
                eventStatusId = events.eventStatusId,
                startCallingDate = events.startCallingDate,
                heightPointAddress = events.heightPointAddress,
                widthPointAddress = events.widthPointAddress ,
                eventName = events.EventName.discribeEventName,
                stringAddress=events.stringAddress,
                count=events.ValunteerEvents.Count
            };
        }
        public static Event convertDtoToDB(EventsDto eventsDto)
        {
          
            return new Event()
            {
               // eventCode = eventsDto.eventCode,
                eventDescription = eventsDto.eventDescription,
                eventNameId = eventsDto.eventNameId,
                eventStatusId = eventsDto.eventStatusId,
                startCallingDate = eventsDto.startCallingDate,
                heightPointAddress=eventsDto.heightPointAddress,
                widthPointAddress=eventsDto.widthPointAddress,
              stringAddress=eventsDto.stringAddress
            };
        }
        public static List<EventsDto> convertDBToDtoList(List<Event> events)
        {
            List<EventsDto> l = new List<EventsDto>();
            events.ForEach(a => l.Add(convertDBToDto(a)));
            return l;
        }
    }
}
