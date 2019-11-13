using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DTO
{
    public class ValunteerEventDto
    {
        public int tzId { get; set; }
        public int eventCodeId { get; set; }
        public int? valunteerStatusInEventId { get; set; }
        public System.DateTime? dateGetEvent { get; set; }

        public static ValunteerEventDto convertDBToDto(ValunteerEvent valunteerEvent)
        {
            return new ValunteerEventDto()
            {
               dateGetEvent= valunteerEvent.dateGetEvent,
               eventCodeId=valunteerEvent.eventCodeId,
               tzId=valunteerEvent.valunteerId,
               valunteerStatusInEventId=valunteerEvent.valunteerStatusInEventId
            };
        }
        public static ValunteerEvent convertDtoToDB(ValunteerEventDto valunteerEventDto)
        {
            return new ValunteerEvent()
            {
                dateGetEvent = valunteerEventDto.dateGetEvent,
                eventCodeId = valunteerEventDto.eventCodeId,
                valunteerId = valunteerEventDto.tzId,
                valunteerStatusInEventId = valunteerEventDto.valunteerStatusInEventId
            };
        }
    }
}
