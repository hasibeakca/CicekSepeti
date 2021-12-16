using CicekSepeti.DAL.Dto.FloristCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Abstract
{
 public   interface IFloristCustomerService
    {
        Task<List<GetListFloristCustomerDto>> GetAllFloristCustomers();

        Task<GetFloristCustomerDto> GetFloristCustomerById(int FloristCustomerId);

        Task<int> AddFloristCustomer(AddFloristCustomerDto addFloristCustomerDto);
        Task<int> UpdateFloristCustomer(UpdateFloristCustomerDto updateFloristCustomerDto);

        Task<int> DeleteFloristCustomer(int FloristCustomerId);
    }
}
