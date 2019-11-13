using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DTO
{
    public class FreindlyEventDto
    {
        public int freindlyCode { get; set; }
        public string freindlyDescription { get; set; }
        public Nullable<double> heightPointAddress { get; set; }
        public Nullable<double> widthPointAddress { get; set; }
        public int? countValunteer { get; set; }

        public System.DateTime? date { get; set; }

        public static List<FreindlyEventDto> convertDBToDtoList(List<FreindlyEvent> list)
        {
                List<FreindlyEventDto> l = new List<FreindlyEventDto>();
                list.ForEach(a => l.Add(convertDBToDto(a)));
                return l;
            
        }

        public Nullable<System.TimeSpan> hour { get; set; }
        public static FreindlyEventDto convertDBToDto(FreindlyEvent freindlyEvent)
        {
            return new FreindlyEventDto()
            {
             freindlyCode=freindlyEvent.freindlyCode,
             freindlyDescription=freindlyEvent.freindlyDescription,
             heightPointAddress=freindlyEvent.heightPointAddress,
             hour=freindlyEvent.hour,
             widthPointAddress=freindlyEvent.widthPointAddress,
             countValunteer= freindlyEvent.countValunteer,
             date= freindlyEvent.date
            };
        }
        public static FreindlyEvent convertDtoToDB(FreindlyEventDto freindlyEventDto)
        {
            return new FreindlyEvent()
            {
                freindlyCode = freindlyEventDto.freindlyCode,
                freindlyDescription = freindlyEventDto.freindlyDescription,
                heightPointAddress = freindlyEventDto.heightPointAddress,
                hour = freindlyEventDto.hour,
                widthPointAddress = freindlyEventDto.widthPointAddress,
                countValunteer= freindlyEventDto.countValunteer,
                date= freindlyEventDto.date
            };
        }
    }
}
