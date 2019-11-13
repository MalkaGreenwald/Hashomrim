using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DTO
{
    public class DetailsValunteerDto
    {
        public string tz { get; set; }
        public int statusValunteerId { get; set; }
        public string statusValunteer { get; set; }
        public System.DateTime silencingRingingUntilDate { get; set; }
        public Nullable<System.DateTime> silencingRingingFronDate { get; set; }
        public static DetailsValunteerDto convertDBToDto(DetailsValunteer detailsValunteer)
        {
            return new DetailsValunteerDto()
            {
                silencingRingingFronDate = detailsValunteer.silencingRingingFronDate,
                silencingRingingUntilDate = detailsValunteer.silencingRingingUntilDate,
                statusValunteerId = detailsValunteer.statusValunteerId,
               statusValunteer = detailsValunteer.StatusValunteer.discribeStatusValunteer
            };
        }
        public static DetailsValunteer convertDtoToDB(DetailsValunteerDto detailsValunteerDto)
        {
            return new DetailsValunteer()
            {
                silencingRingingFronDate = detailsValunteerDto.silencingRingingFronDate ,
                silencingRingingUntilDate = detailsValunteerDto.silencingRingingUntilDate,
                statusValunteerId = detailsValunteerDto.statusValunteerId
            };
        }

    }
}
