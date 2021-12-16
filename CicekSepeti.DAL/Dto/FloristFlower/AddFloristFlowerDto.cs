using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.DAL.Dto.FloristFlower
{
  public  class AddFloristFlowerDto:IDto
    {
        public int FloristId { get; set; }
        public int FlowerId { get; set; }
    }
}
