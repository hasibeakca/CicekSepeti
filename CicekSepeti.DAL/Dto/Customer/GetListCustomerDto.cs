using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.DAL.Dto.Customer
{
    public class GetListCustomerDto : IDto
    {
        public int Id { get; set; }
        public int CustomerNo { get; set; }
        public string Name { get; set; }
    }
}
