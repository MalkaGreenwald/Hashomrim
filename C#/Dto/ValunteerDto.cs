using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DTO
{
    public class ValunteerDto
    {
        public string tz { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public Nullable<int> cityId { get; set; }
        public Nullable<double> hieghtPointAddress { get; set; }
        public Nullable<int> personalSituationId { get; set; }
        public Nullable<double> widthPointAddress { get; set; }

        public string addressVolunteer { get; set; }
        public DetailsValunteerDto VolunteerDetail { get; set; } = new DetailsValunteerDto();

        public List<HistoryStatusValunteerDto> HistoryStatusValunteer { get; set; }

        public List<ValunteerEventDto> ValunteerEvent { get; set; }

        public static ValunteerDto convertDBToDto(Valunteer valunteer)
        {

            return new ValunteerDto()
            {
                cityId = valunteer.cityId,
                firstName = valunteer.firstName,
                lastName = valunteer.lastName,
                personalSituationId = valunteer.personalSituationId,
                phone = valunteer.phone,
                tz = valunteer.tz,
                hieghtPointAddress = valunteer.hieghtPointAddress,
                widthPointAddress = valunteer.widthPointAddress,
                VolunteerDetail = DetailsValunteerDto.convertDBToDto(valunteer.DetailsValunteer),
                addressVolunteer=valunteer.addressVolunteer

            };
        }
        public static Valunteer convertDtoToDB(ValunteerDto valunteerDto)
        {
            return new Valunteer()
            {
                cityId = valunteerDto.cityId,
                firstName = valunteerDto.firstName,
                lastName = valunteerDto.lastName,
                personalSituationId = valunteerDto.personalSituationId,
                phone = valunteerDto.phone,
                tz = valunteerDto.tz,
                hieghtPointAddress = valunteerDto.hieghtPointAddress,
                widthPointAddress = valunteerDto.widthPointAddress,
                DetailsValunteer=DetailsValunteerDto.convertDtoToDB(valunteerDto.VolunteerDetail)    ,
                addressVolunteer=valunteerDto.addressVolunteer
            };
        }
        public static List<ValunteerDto> convertDBToDtoList(List<Valunteer> valunteers)
        {
            List<ValunteerDto> l = new List<ValunteerDto>();
            valunteers.ForEach(a => l.Add(convertDBToDto(a)));
            return l;
        }
    }
}
