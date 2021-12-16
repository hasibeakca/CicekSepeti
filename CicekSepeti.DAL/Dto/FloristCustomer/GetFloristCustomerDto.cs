﻿using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.DAL.Dto.FloristCustomer
{
 public   class GetFloristCustomerDto:IDto
    {
        public int Id { get; set; }
        public int FloristId { get; set; }
        public int CustomerId { get; set; }
        public string FloristName { get; set; }
        public string CustomerName { get; set; }
        public int FloristNumber { get; set; }

    }
}
