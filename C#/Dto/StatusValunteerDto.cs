using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DTO
{
    class StatusValunteerDto
    {
        public int statusValunteerId { get; set; }
        public string discribeStatusValunteer { get; set; }
        public static StatusValunteerDto convertDBToDto(StatusValunteer statusValunteer)
        {
            return new StatusValunteerDto()
            {
                discribeStatusValunteer= statusValunteer.discribeStatusValunteer,
                statusValunteerId= statusValunteer.statusValunteerId

            };
        }
        public static StatusValunteer convertDtoToDB(StatusValunteerDto statusValunteerDto)
        {
            return new StatusValunteer()
            {
                discribeStatusValunteer = statusValunteerDto.discribeStatusValunteer,
                statusValunteerId = statusValunteerDto.statusValunteerId

            };


        }
    }
}
