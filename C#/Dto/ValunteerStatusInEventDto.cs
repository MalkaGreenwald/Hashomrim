using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DTO
{
    class ValunteerStatusInEventDto
    {
        public int valunteerStatusInEventId { get; set; }
        public string discribeValunteerStatusInEvent { get; set; }
        public static ValunteerStatusInEventDto convertDBToDto(ValunteerStatusInEvent ValunteerStatusInEvent)
        {
            return new ValunteerStatusInEventDto()
            {
                discribeValunteerStatusInEvent = ValunteerStatusInEvent.discribeValunteerStatusInEvent,
                valunteerStatusInEventId = ValunteerStatusInEvent.valunteerStatusInEventId
            };
        }
        public static ValunteerStatusInEvent convertDtoToDB(ValunteerStatusInEventDto ValunteerStatusInEventDto)
        {
            return new ValunteerStatusInEvent()
            {

                discribeValunteerStatusInEvent = ValunteerStatusInEventDto.discribeValunteerStatusInEvent,
                valunteerStatusInEventId = ValunteerStatusInEventDto.valunteerStatusInEventId
            };
        }
    }
}
