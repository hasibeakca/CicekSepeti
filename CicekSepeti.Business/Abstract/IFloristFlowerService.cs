using CicekSepeti.DAL.Dto.FloristFlower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Abstract
{
    public interface IFloristFlowerService
    {
        Task<List<GetListFloristFlowerDto>> GetAllFloristFlowers();

        Task<GetFloristFlowerDto> GetFloristFlowerById(int FloristFlowerId);

        Task<int> AddFloristFlower(AddFloristFlowerDto addFloristFlowerDto);
        Task<int> UpdateFloristFlower(UpdateFloristFlowerDto updateFloristFlowerDto);

        Task<int> DeleteFloristFlower(int FloristFlowerId);
    }
}
