using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.DAL.Dto.FloristFlower
{
  public  class UpdateFloristFlowerDto :IDto
    {
        public int Id { get; set; }
        public int FloristId { get; set; }
        public int FlowerId { get; set; }
        public string FloristName { get; set; }
        public string FlowerName { get; set; }
        public int FloristNumber { get; set; }
    }
}
