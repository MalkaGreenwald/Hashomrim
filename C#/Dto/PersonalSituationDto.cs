using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DTO
{
    public class PersonalSituationDto
    {
        public int personalSituationId { get; set; }
        public string discribe { get; set; }
        public static PersonalSituationDto convertDBToDto(PersonalSituation personalSituation)
        {
            return new PersonalSituationDto()
            {
               discribe=personalSituation.discribe,
               personalSituationId=personalSituation.personalSituationId
            };
        }

        public static List<PersonalSituationDto> convertDBToDtoList(List<PersonalSituation> PersonalSituationlist)
        {
            List<PersonalSituationDto> l = new List<PersonalSituationDto>();
            PersonalSituationlist.ForEach(a => l.Add(convertDBToDto(a)));
            return l;
        }

        public static PersonalSituation convertDtoToDB(PersonalSituationDto personalSituationDto)
        {
            return new PersonalSituation()
            {
                discribe = personalSituationDto.discribe,
                personalSituationId = personalSituationDto.personalSituationId
            };
        }
    }
}
