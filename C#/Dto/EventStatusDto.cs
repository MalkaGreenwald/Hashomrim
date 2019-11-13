using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DTO
{
    public class EventStatusDto
    {
        public int eventStatusId { get; set; }
        public string discribeEventStatus { get; set; }
        public static EventStatusDto convertDBToDto(EventStatu eventStatus)
        {
            return new EventStatusDto()
            {
                discribeEventStatus=eventStatus.discribeEventStatus,
                eventStatusId=eventStatus.eventStatusId
            };
        }
        public static EventStatu convertDtoToDB(EventStatusDto eventStatusDto)
        {
            return new EventStatu()
            {
                discribeEventStatus = eventStatusDto.discribeEventStatus,
                eventStatusId = eventStatusDto.eventStatusId
            };
        }
        public static List<EventStatusDto> convertDBToDtoList(List<EventStatu> eventStatusList)
        {
            List<EventStatusDto> l = new List<EventStatusDto>();
             eventStatusList.ForEach(a => l.Add(convertDBToDto(a)));
            return l;
        }
    }
}
