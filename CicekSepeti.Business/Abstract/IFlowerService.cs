using CicekSepeti.DAL.Dto.Flower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Abstract
{
    public interface IFlowerService
    {
        Task<List<GetListFlowerDto>> GetAllFlowers();

        Task<GetFlowerDto> GetFlowerById(int FlowerId);
         
        Task<int> AddFlower(AddFlowerDto addFlowerDto);
        Task<int> UpdateFlower(UpdateFlowerDto updateFlowerDto);

        Task<int> DeleteFlower(int FlowerId);
    }
}
