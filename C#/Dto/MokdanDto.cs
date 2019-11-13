using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DTO
{
   public  class MokdanDto
    {
        public int? idMokdan { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public static MokdanDto convertDBToDto(Mokdan mokdan)
        {
            return new MokdanDto()
            {
               idMokdan=mokdan.idMokdan,
                userName = mokdan.userName,
               password=mokdan.password
            };
        }
        public static Mokdan convertDtoToDB(MokdanDto mokdanDto)
        {
            return new Mokdan()
            {
                //idMokdan = mokdanDto.idMokdan,
                userName = mokdanDto.userName,
                password = mokdanDto.password
            };
        }
    }
}
