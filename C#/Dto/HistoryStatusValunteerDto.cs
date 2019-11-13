using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DTO
{
    public class HistoryStatusValunteerDto
    {
        public int id { get; set; }
        public int statusValunteerId { get; set; }
        public ValunteerDto ValunteerDto { get; set; }
        public System.DateTime silencingRingingUntilDate { get; set; }
        public System.DateTime silencingRingingFromDate { get; set; }
        public static HistoryStatusValunteerDto convertDBToDto(HistoryStatusValunteer historyStatusValunteer)
        {
            return new HistoryStatusValunteerDto()
            {
                id=historyStatusValunteer.id,
                silencingRingingFromDate=historyStatusValunteer.silencingRingingFromDate,
            silencingRingingUntilDate=historyStatusValunteer.silencingRingingUntilDate,
            statusValunteerId=historyStatusValunteer.statusValunteerId,
            ValunteerDto=ValunteerDto.convertDBToDto(historyStatusValunteer.Valunteer)
            };
        }
        public static HistoryStatusValunteer convertDtoToDB(HistoryStatusValunteerDto historyStatusValunteerDto)
        {
            return new HistoryStatusValunteer()
            {

                id = historyStatusValunteerDto.id,
                silencingRingingFromDate = historyStatusValunteerDto.silencingRingingFromDate,
                silencingRingingUntilDate = historyStatusValunteerDto.silencingRingingUntilDate,
                statusValunteerId = historyStatusValunteerDto.statusValunteerId,
                Valunteer=ValunteerDto.convertDtoToDB(historyStatusValunteerDto.ValunteerDto)

            };
        }
    }
}
