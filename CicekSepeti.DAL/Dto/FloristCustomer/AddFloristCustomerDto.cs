using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.DAL.Dto.FloristCustomer
{
   public class AddFloristCustomerDto:IDto
    {
        public int FloristId { get; set; }
        public int CustomerId { get; set; }
    }
}
