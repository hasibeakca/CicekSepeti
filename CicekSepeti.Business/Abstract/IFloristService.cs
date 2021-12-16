using CicekSepeti.DAL.Dto.Florist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Abstract
{
  public  interface IFloristService
    {
        Task<List<GetListFloristDto>> GetAllFlorists();

        Task<GetFloristDto> GetFloristById(int FloristId);

        Task<int> AddFlorist(AddFloristDto addFloristDto);
        Task<int> UpdateFlorist(UpdateFloristDto updateFloristDto);

        Task<int> DeleteFlorist(int FloristId);
    }
}
